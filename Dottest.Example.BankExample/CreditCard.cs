using System;
using System.IO;
using System.Text;
using Dottest.Example.BankExample.Transactions;

namespace Dottest.Example.BankExample
{
    /// <summary>
    /// CreditCard is a simple class supporting basic operations
    /// such as charging (AddToBalance), making payments (transfering
    /// money from BankAccount), and displaying simple statements.
    /// 
    /// This class also involves some validation routines that 
    /// illustrate how one can modify automatically generated 
    /// tests to easily improve coverage.
    /// </summary>
    public sealed class CreditCard
    {
        /// <summary>
        /// Constructor with validation. Large number of automatically
        /// generated calls to this constructor fail validation. This
        /// illustrates how .TEST can be used to generate initial test cases
        /// and later modify them if necesary.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="id"></param>
        /// <param name="securityNumber"></param>
        /// <param name="name"></param>
        /// <param name="zip"></param>
        /// <param name="cardNumber"></param>
        public CreditCard(
            int balance, 
            int id, 
            string securityNumber, 
            string name, 
            string zip, 
            string cardNumber)
        {
            CurrentBalance = balance;
            CustomerId = id;
            SocialSecurityNumberString = securityNumber;
            CustomerName = name;
            ZipCodeString = zip;
            CreditCardNumberString = cardNumber;
            if (!Validate())
            {
                throw new ArgumentException("Invalid credit card data");
            }
        }
        /// <summary>
        /// Constructor without validation of inputs. This helps 
        /// to illustrate some of the unit testing features better.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public CreditCard(
            int balance, 
            int id, 
            string name) 
        {
            CurrentBalance = balance;
            CustomerId = id;
            CustomerName = name;
            ZipCodeString = "0000";
            CreditCardNumberString = "0000-0000-0000-0000";
        }

        private bool Validate()
        {
            return Validate(new int[] { 5 }, ZipCodeString)
                && Validate(new int[] { 3, 2, 4 }, SocialSecurityNumberString)
                && Validate(new int[] { 4, 4, 4, 4 }, CreditCardNumberString)
                && CurrentBalance > 0 && CustomerId > 0
                && CustomerName.Length != 0;
        }

        
        /// <summary>
        /// Validates the input string using an array of digit 
        /// sequence lengths, separated by dashes. 
        /// E.g. "123-45-6789" is a sequence of 3 digits,
        /// followed by dash, followed by sequence of 2 digits, dash, 
        /// and a sequence of 4 digits. Thus digLenths array
        /// will have {3, 2, 4} in it.
        /// 
        /// </summary>
        private static bool Validate(
            int[] digLengths, 
            string input) 
        {
            // index into the input string
            int index = 0;
            for (int i = 0; i < digLengths.Length; i++) 
            {
                int length = digLengths[i];
                // expect the dash between digit sequences
                if (i != 0 
                    && (index == input.Length || input[index++] != '-'))
                    return false;
                // expect a sequence of digits of given length
                for (int j = 0; j < length; j++) 
                {
                    if (index == input.Length || !Char.IsDigit(input[index++]))
                    {
                        return false;
                    }
                }
            }
            return index == input.Length;
        }

        
        public void DisplayStatement() 
        {
            Console.WriteLine("Customer Name: " + CustomerName); // parasoft-suppress  PB.CONSOLEWRITE "This WriteLine is OK"
            Console.WriteLine("Account Number: " + CustomerId);
            Console.WriteLine("Credit Card Number: xxxx-xxxx-xxxx-"
                + CreditCardNumberString[15]);
            Console.WriteLine("Balance: $" + CurrentBalance + ".00");
        }

        
        /// <summary>
        /// Makes a credit card payment from the customer's bank account.
        /// </summary>
        /// <param name="account">bank account</param>
        /// <exception cref="ArgumentException">
        /// bank account customer id does not match the credit card
        /// customer id
        /// </exception>
        public void MakePayment(string accountId)
        {
            try
            {
                BankAccount account = Bank.Instance.GetAccount(accountId);
                if (accountId == null)
                    throw new ArgumentException("Wrong account id");
                
                TransactionBase transaction = new Withdraw(account, CurrentBalance);
                Bank.Instance.Apply(transaction);

                CurrentBalance = 0;
            }
            catch (ArgumentException )
            {
                Console.WriteLine("Arg Exception");
            }
        }

        
        private string _creditCardNumber;
        public string CreditCardNumberString
        {
            get 
            {
                return _creditCardNumber;
            }

            set
            {
                _creditCardNumber = value;
            }
        }

        private int _currentBalance;
        public int CurrentBalance 
        {
            get
            {
                return _currentBalance;
            }


            set
            {
                _currentBalance = value;
            }
        }

        public void AddToBalance(int delta)
        {
            _currentBalance =+ delta; // programmer meant to use +=
        }
        private int _customerId;
        public int CustomerId
        {
            get
            {
                return _customerId;
            }
       
            set
            {
                _customerId = value;
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
        

            set
            {
                _customerName = value;
            }
        }

        private string _socialSecurityNumber;
        public string SocialSecurityNumberString
        {
            get
            {
                return _socialSecurityNumber;
            }

            set 
            {
                _socialSecurityNumber = value;
            }
        }

        public string _zipcode;
        public string ZipCodeString
        {
            get
            {
                return _zipcode;
            }
            set
            {
                _zipcode = value;
            }
        }

        public override int GetHashCode()
        {
            return _creditCardNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (obj.GetHashCode() == GetHashCode());
        }

        private StreamWriter GetStreamWriter()
        {
            string tmpPath = System.Environment.GetEnvironmentVariable("TEMP");
            string fname = CustomerName + ".txt";
            string filePath = System.IO.Path.Combine(tmpPath, fname);
            if (filePath.Length > 200)
            {
                return null;
            }
            // NOTE: There is a potential security breach here since
            // the value obtained from an environment variable is used
            // without validation.
            StreamWriter sw = new StreamWriter(filePath);
           
            return sw;
 
        }
     
        public void GenerateReport()
        {
            StreamWriter sw = GetStreamWriter();
            // NOTE: sw can be null since GetStreamWriter returns
            // null under some circumstances.
            sw.WriteLine("Balance: " + CurrentBalance);
            sw.WriteLine("CustomerName: " + CustomerName);
            sw.Close();
            // NOTE: There is a resource leak here in case WriteLine
            // throws an exception. The Close() method call should be
            // in a finally block.
        }

        private void GenerateReportHeader(StreamWriter sw)
        {
            sw.WriteLine("Report for account: " + _creditCardNumber);
        }

        public string GetCreditCardInfo()
        {
            StringBuilder creditCardInfo = new StringBuilder();
            creditCardInfo.AppendLine(_creditCardNumber);
            creditCardInfo.AppendLine(this.CustomerName);
            creditCardInfo.ToString();
            return _creditCardNumber;
        }
    }
}

