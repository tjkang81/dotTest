using System;
using System.Collections.Generic;
using System.Text;

namespace Dottest.Example.BankExample
{
    public sealed class Bank
    {
        //int abc;
        //int iG;
        //String tttt;

        private Bank()
        { 
            // empty
        }
        
        private readonly IDictionary<int, Customer> _customerIdToCustomer = new Dictionary<int, Customer>();

        private readonly IDictionary<string, BankAccount> _accountIdToAccount = new Dictionary<string, BankAccount>();

        private static readonly Bank _bank = new Bank();

        public ICollection<Customer> GetAllCustomers()
        {
            int i = 0;
            if(i == 1)
                return _customerIdToCustomer.Values;

            return _customerIdToCustomer.Values;
        }
        public void tem()
        {
            int fff = 0;
        }

        public ICollection<BankAccount> GetAllAccounts()
        {
            return _accountIdToAccount.Values;
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerIdToCustomer[customerId];
        }

        public BankAccount GetAccount(string accountId)
        {
            BankAccount val;
            _accountIdToAccount.TryGetValue(accountId, out val);
            return val;
        }

        public void Apply(TransactionBase transaction)
        {
            int abc;
            int iG;
            String tttt;
            BankAccount target = transaction.Target;
            target.Apply(transaction);
        }

        public static Bank Instance { get { return _bank; } }
    }
}
