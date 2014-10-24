using Dottest.Example.BankExample;
using Dottest.Example.BankExample.DotTest.Factories;
using Dottest.Framework;
using Dottest.Framework.RecordState;
using NUnit.Framework;
using System;

namespace Dottest.Example.BankExample.DotTest
{
    [TestFixture()]
    public class CustomerTests
    {
        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+/kCPA")]
        public void TestVerifyCustomerInformation01()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = string.Empty;
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory02();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+oo8WQ")]
        public void TestVerifyCustomerInformation02()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = "John Gray";
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory03();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+sqTvw")]
        public void TestVerifyCustomerInformation03()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = string.Empty;
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory03();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+FYxCA")]
        public void TestVerifyCustomerInformation04()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = "John Gray";
            string ssn = "foo";
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "/x6F+A")]
        public void TestVerifyCustomerInformation05()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = string.Empty;
            string ssn = "foo";
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+Gw4ig")]
        public void TestVerifyCustomerInformation06()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = "John Gray";
            string ssn = null;
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [ExpectedException("System.NullReferenceException")]
        [Test]
        [HashCode("+7R54g", "/ySMeg")]
        public void TestVerifyCustomerInformation07()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = string.Empty;
            string ssn = null;
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            // ExpectedException custom attribute was generated instead of
            // assertions since the test threw System.NullReferenceException
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+O0fXw")]
        public void TestVerifyCustomerInformation08()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = "John Gray";
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory01();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+K2wuQ")]
        public void TestVerifyCustomerInformation09()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = string.Empty;
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory01();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsTrue(b);   // example failing assertion
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+7mt2g")]
        public void TestVerifyCustomerInformation10()
        {
            Customer customer = CustomerFactory.CreateCustomer06();
            string name = "John Gray";
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory02();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsFalse(b);
            #endregion
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        [HashCode("+7R54g", "+ZOTnQ")]
        public void TestVerifyCustomerInformation11()
        {
            Customer customer = CustomerFactory.CreateCustomer01();
            string name = "Jack Black";
            string ssn = SocialSecurityNumberFactory.CreateSocialSecurityNumberFactory02();
            bool b = customer.VerifyCustomerInformation(name, ssn);
            #region Record State
            ValueRecorder recorder = new ValueRecorder();
            recorder.Record(b);
            recorder.FinishRecording();
            #endregion
            #region Assertions
            Assert.IsTrue(b);
            #endregion
        }
    }
}