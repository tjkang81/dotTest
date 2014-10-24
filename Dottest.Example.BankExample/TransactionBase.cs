using System;

namespace Dottest.Example.BankExample
{
    /// <summary>
    /// An abstract base class for all transactions. All transactions
    /// have a transaction fee associated with them.
    /// </summary>
    public abstract class TransactionBase
    {
        BankAccount _target;
        
        private int _transactionFee;

        public TransactionBase (BankAccount target, int transaction_fee) 
        {
            _target = target;
            _transactionFee = transaction_fee;
        }

        public int getTransactionFee () 
        {
            return _transactionFee;
        }

        public BankAccount Target
        {
            get { return _target; }
        }
    }
}
