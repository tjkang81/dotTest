using System;

namespace Dottest.Example.BankExample
{
    /// <summary>
    /// This class represents one customer. Each customer
    /// is chracterized by a name, zip, and social security
    /// number. But this implementation obviously has many bugs!
    /// </summary>
    public sealed class Customer
    {
        private string _name;
        private int    _zip;
        private string _ssn;

        public Customer (string name, int zip) 
        {
            _name = name;
            _zip = zip;
        }

        public string SocialSecurityNumber
        {
            get
            {
                return _ssn;
            }
            set
            {
                _ssn = value;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Zip
        {
            get { return _zip; }
        }

        public bool VerifyCustomerInformation(
            string name,
            string ssn)
        {
            if ((ssn != null) & ssn.Equals(_ssn))
            {
                return true;
            }
            return false;
        }

        public void ChangeCustomerInformation(int newZip, string ssn)
        {
            if (newZip < 0)
            {
                throw new ArgumentException("Zip cannot be negative");
            }

            _zip = newZip;
            _ssn = ssn;
        }

        internal string GetShortInfo()
        {
            return _name + " " + _zip + " " + _ssn;
        }
    }
}
