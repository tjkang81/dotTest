using System;
using System.Collections;
using System.Threading;
using Dottest.Example.BankExample.Transactions;

namespace Dottest.Example.BankExample
{
    /// <summary>
    /// This class contains the details of a single bank account.
    /// </summary>
    public class BankAccount
    {
        static void Main(string[] args)
        {
            // for testing purposes
        }

        private int _customerId;
        private int _balance;
        private TransactionBase[] _transactions;
        private int _capacity;
        private int _transactionCount;

        private DateTime _lastModification;

        private readonly DateTime _time = DateTime.Now;
        
        public BankAccount(int customer_id, int initial_balance)
        {
            _customerId = customer_id;
            _balance   = initial_balance;
            _capacity = 10;
            _transactions = new TransactionBase[_capacity];
            _transactionCount = 0;
        }

        public int CustomerId
        {
            get
            {
                return _customerId;
            }
        }

        public int Balance
        {
            get
            {
                return _balance;
            
            }
        }
        /// <summary>
        /// TrackTransaction keeps a list of all transactions. This 
        /// can be used for various queries. This is used in 
        /// GetDepositTotal for illustration purposes.
        /// </summary>
        /// <param name="newTrans"> New transaction to be added to the
        /// list of transactions.
        /// </param> 
        private void TrackTransaction(TransactionBase newTrans)
        {
            if (_transactionCount < _capacity)
            {
                _transactions[_transactionCount] = newTrans;
                _transactionCount++;
                return;
            }
            _capacity += 100;
            TransactionBase[] tmp = new TransactionBase[_capacity];
            for (int i = 0; i < _transactionCount; ++i)
            {
                tmp[i] = _transactions[i];
            }
            tmp[_transactionCount] = newTrans;
            _transactionCount++;
            _transactions = tmp;
        }
        /// <summary>
        /// GetDepositTotal() returns the sum of all the deposits 
        /// made on this account so far.
        /// </summary>
        /// <returns> The sum of all the deposits made so far on this account.
        /// </returns>
        public int GetDepositTotal()
        {
            int sum = 0;
            for (int i = 0; i < _transactionCount; ++i)
            {
                TransactionBase trans = _transactions[i];
                if (trans is Deposit)
                {
                    Deposit dep = (Deposit) trans;
                    sum += dep.getAmount();
                }
            }
            return sum;
        }
        /// <summary>
        /// Performs a transaction on the bank account, deducting
        /// any transaction fees. Transaction may be a deposit, 
        /// withdraw, or a change of ownership.
        /// </summary>
        public void Apply (TransactionBase transaction)
        {
            TrackTransaction(transaction);
            if (transaction is Deposit)
            {
                Apply0 ((Deposit) transaction);
            }
            else if (transaction is Withdraw)
            {
                Apply0 ((Withdraw) transaction);
            }
            else if (transaction is ChangeOwnership)
            {
                Apply0 ((ChangeOwnership) transaction);
            }
            _balance -= transaction.getTransactionFee ();
        }

        private void Apply0 (Deposit deposit) 
        {
            _balance += deposit.getAmount ();

            //_balance += 2;
            NotifyModification();
        }

        private void Apply0 (Withdraw withdraw) 
        {
            _balance -= withdraw.getAmount ();
        }

        private void Apply0 (ChangeOwnership co) 
        {
            _customerId = co.getNewCustomerId ();
        }

        private void Apply0(CreditCard cc)
        {
            string name = cc.CustomerName;
            CreditCard cc2 = new CreditCard(cc.CurrentBalance, cc.CustomerId, name);
            Apply0(cc2);
        }

        public static int GetTransactionAmount(TransactionBase trans)
        {
            Deposit dep = trans as Deposit;
            if (dep != null)
            {
                return dep.getAmount();
            }
            Withdraw wit = trans as Withdraw;
            return wit.getAmount();
        }

        public DateTime GetLastModification()
        {
            Monitor.Enter(_time);
            try
            {
                return _lastModification;
            }
            finally
            {
                Monitor.Exit(_time);
            }
        }

        private void NotifyModification()
        {
            Monitor.Enter(_time);
            _lastModification = DateTime.Now;
            Monitor.Exit(_time);
        }

        public override string ToString()
        {
            try
            {
                return base.ToString();
            }
            catch (NullReferenceException)
            {
                return "";
            }
        }
    }
}
