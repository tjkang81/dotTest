using System;

namespace Dottest.Example.BankExample.Transactions
{
    public sealed class Deposit : TransactionBase
    {
        private int _amount;

        //Fee to charge on every deposit transaction.    
        private static /*readonly */int Transaction_Fee = 1;

        public Deposit (BankAccount target, int amount) : base (target, Transaction_Fee) 
        {
            _amount = amount;
        }

        public int getAmount ()
        {
            return _amount;
        }
    }
}
