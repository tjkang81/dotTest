using Dottest.Framework;
using NUnit.Framework;
using System;
using Dottest.Framework.RecordState;

namespace Dottest.Example.BankExample.DotTest.Factories
{
    [TestFixture(), ObjectFactoryType()]
    public class SocialSecurityNumberFactory
    {
        [ObjectFactoryMethod]
        public static string CreateSocialSecurityNumberFactory01()
        {
            return "223-12-4123";
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        public void TestCreateSolcialSecurityNumberFactory01()
        {
            string str = CreateSocialSecurityNumberFactory01();
            Assert.IsNotNull(str);

            #region Record State
            ValueRecorder vr = new ValueRecorder();
            vr.Record(str);
            vr.FinishRecording();
            #endregion
            #region Assertions
            Assert.AreEqual("223-12-4123", str);
            #endregion
        }

        [ObjectFactoryMethod]
        public static string CreateSocialSecurityNumberFactory02()
        {
            return "821-32-3123";
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        public void TestCreateSolcialSecurityNumberFactory02()
        {
            string str = CreateSocialSecurityNumberFactory02();
            Assert.IsNotNull(str);

            #region Record State
            ValueRecorder vr = new ValueRecorder();
            vr.Record(str);
            vr.FinishRecording();
            #endregion
            #region Assertions
            Assert.AreEqual("821-32-3123", str);
            #endregion
        }

        [ObjectFactoryMethod]
        public static string CreateSocialSecurityNumberFactory03()
        {
            return "187-54-0045";
        }

        [TestCaseUnverified("Test case not verified")]
        [TestCaseAutogenerated]
        [Test]
        public void TestCreateSolcialSecurityNumberFactory03()
        {
            string str = CreateSocialSecurityNumberFactory03();
            Assert.IsNotNull(str);

            #region Record State
            ValueRecorder vr = new ValueRecorder();
            vr.Record(str);
            vr.FinishRecording();
            #endregion
            #region Assertions
            Assert.AreEqual("187-54-0045", str);
            #endregion
        }

    }
}