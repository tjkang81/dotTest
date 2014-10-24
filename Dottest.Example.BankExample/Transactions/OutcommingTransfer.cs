using System;
using System.Collections.Generic;
using System.Text;

namespace Dottest.Example.BankExample.Transactions
{
    public class OutcommingTransfer : TransactionBase
    {
        int _amount;
        string _targetAccountId;
        IExternalBank _targetBank;

        public OutcommingTransfer(BankAccount source, int amount,
            string targetAccountId, IExternalBank targetBank) : base(source, 1)
        {
            _amount = amount;
            _targetAccountId = targetAccountId;
            _targetBank = targetBank;
        }
    }
}
