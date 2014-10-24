using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dottest.Example.BankExample
{
    /// <summary>
    /// This class maintains information about a group
    /// of customers. One can then perform queries such as
    /// the average balance for the customers in the group etc.
    /// 
    /// This has some complex methods that illustrate the power
    /// of BugDetective.
    /// </summary>
    public class CustomerGroup
    {
        Hashtable _customerToAccountMap;

        public CustomerGroup()
        {
           _customerToAccountMap = new Hashtable();
        }

        private System.Data.Odbc.OdbcConnection GetOdbcConnection(
            string connStr)
        {
            System.Data.Odbc.OdbcConnection oc = 
                new System.Data.Odbc.OdbcConnection(connStr);
            oc.Open();
            return oc;
        }

        /// <summary>
        /// Initailizes the customer group with data from the
        /// given database.
        /// </summary>
        /// <param name="connStr"></param>
        public void GetCustomersFromDB(string connStr)
        {
            System.Data.Odbc.OdbcConnection oc = GetOdbcConnection(connStr);
            RunCommandsToGetCustomerData(oc);
            // NOTE: There is a resource leak here. The OdbcConnection opened
            // in GetOdbcConnection is not closed.
            oc.Close();
           
        }

        private void RunCommandsToGetCustomerData(System.Data.Odbc.OdbcConnection oc)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        internal IList<BankAccount> AccountsChangedAfter2010()
        {
            List<BankAccount> list
                = new List<BankAccount>();
            foreach (Customer customer in _customerToAccountMap.Values) {
                BankAccount current =
                    (BankAccount)_customerToAccountMap[ customer ];
                DateTime time = current.GetLastModification();
                if (time >= (new DateTime(2011, 1, 1))) {
                    list.Add(current);
                }
            }
            return list;
        }

        /// <summary>
        /// Adds a customer to the customer group without any account.
        /// </summary>
        public void AddCustomer(Customer cust)
        {
            _customerToAccountMap.Add(cust, null);
        }

        /// <summary>
        /// Adds a customer to the customer group.
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="ba"></param>
        public void AddCustomer(Customer cust, BankAccount ba)
        {
            _customerToAccountMap.Add(cust, ba);
        }

        /// <summary>
        /// Searches the customer group for a customer with the
        /// given name and returns the Customer object.
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Returns null if customer is not found.</returns>
        /// <exception>Throws an ApplicationException  if there are 
        /// no customers in the customer group.
        /// </exception>
        Customer LookupCustomerName(string name)
        {
            if (_customerToAccountMap.Count == 0)
            {
                throw new ApplicationException("No entries in table");
            }
            IDictionaryEnumerator ide = _customerToAccountMap.GetEnumerator();
            while (ide.MoveNext())
            {
                Customer cust = (Customer)ide.Key;
                if (cust.Name.Equals(name))
                {
                    return cust;
                }
            }
            return null;
        }

        /// <summary>
        /// Fetches the balance in the BankAccount of the given 
        /// customer.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetCustomerBalance(string name)
        {
            Customer cust = null;
            int bal = 0;
            try
            {
                cust = LookupCustomerName(name);
                BankAccount bacct = (BankAccount)_customerToAccountMap[cust];
                bal = bacct.Balance;
            }
            catch (Exception e)
            {
                // NOTE: cust below can be null when LookupCustomerName()
                // throws an exception or _customerAccountMap[cust] throws
                // an exception.
                System.Console.WriteLine("Problems with customer " 
                    + cust.ToString());
            }
            return bal;
        }

        public int GetAverageBalance(string match)
        {
            int sum = 0;
            int numCustomers = 0;
            foreach (Customer cust in _customerToAccountMap)
            {
                string name = cust.Name;
                if (name.LastIndexOf(match) >= 0)
                {
                    BankAccount ba = (BankAccount)_customerToAccountMap[cust];
                    sum += ba.Balance;
                    numCustomers++;
                }
            }
            int avg = sum / numCustomers;
            return avg;
        }
        
        internal ICollection<BankAccount> GetAccountsModifiedAfter2009()
        {
            IList<BankAccount> list = new List<BankAccount>();
            foreach (Customer customer in _customerToAccountMap.Values)
            {
                BankAccount current = (BankAccount)_customerToAccountMap[customer];
                DateTime time = current.GetLastModification();
                if (time >= new DateTime(2010, 1, 1))
                {
                    list.Add(current);
                }
        
            }
            return list;
        }



        /// <summary>
        /// Searches for a customer. 
        /// </summary>
        public ICollection FindCustomer(string substr)
        {
            IList list = new ArrayList();
            foreach (Customer cust in _customerToAccountMap.Values)
            {
                if (cust.Name.IndexOf(substr) > 0)
                {
                    list.Add(cust);
                }
            }
            return list;
        }
    }
}
