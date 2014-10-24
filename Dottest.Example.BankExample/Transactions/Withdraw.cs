using System;

namespace Dottest.Example.BankExample.Transactions
{
    public sealed class Withdraw : TransactionBase
    {
        private int _amount;

        public Withdraw (BankAccount target, int amount): base (target, 1)
        {
            _amount = amount;
        }
    
        public int getAmount ()
        {
            return _amount;
        }
    }
}
