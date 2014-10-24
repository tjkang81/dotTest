using System;

namespace Dottest.Example.BankExample.Transactions
{
    /// <summary>
    /// This class handles the transaction for changing the 
    /// ownership of an account.
    /// </summary>
    public sealed class ChangeOwnership : TransactionBase
    {
        private int _newCustomerId;

        public ChangeOwnership(BankAccount target, int new_customer_id)
            : base(target, 20)
        {
            _newCustomerId = new_customer_id;
        }

        public int getNewCustomerId () 
        {
            return _newCustomerId;
        }
    }
}
