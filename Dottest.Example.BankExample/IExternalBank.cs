using System;
using System.Collections.Generic;
using System.Text;

namespace Dottest.Example.BankExample
{
    public interface IExternalBank
    {
        void SendMoney(string targetAccountId, int amount);

        event ReceiveMoneyDelegate ReceiveMoney;
    }

    public delegate void ReceiveMoneyDelegate(string targetAccountId, int amount);
}

