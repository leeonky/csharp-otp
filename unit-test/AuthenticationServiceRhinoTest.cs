using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using csharp_otp;
using Rhino.Mocks;

namespace unit_test
{
    [TestFixture]
    class AuthenticationServiceRhinoTest
    {
        MockRepository mocks;
        ProfileDao profileDao;
        RsaToken rsaToken;
        Logger logger;
        AuthenticationService authenticationService;

        [SetUp]
        public void SetUpAll()
        {
            mocks = new MockRepository();
            profileDao = mocks.Stub<ProfileDao>();
            rsaToken = mocks.Stub<RsaToken>();
            logger = mocks.StrictMock<Logger>();
            authenticationService = new AuthenticationService(profileDao, rsaToken, logger);
        }

        
        [Test]
        public void valid()
        {
            Expect.Call(profileDao.GetPassword(Arg<string>.Is.Equal("joey"))).Return("91");
            Expect.Call(rsaToken.GetRandom(Arg<string>.Is.Equal("joey"))).Return("000000");
            mocks.ReplayAll();

            Assert.IsTrue(authenticationService.IsValid("joey", "91000000"));
        }

        [Test]
        public void invalid()
        {
            Expect.Call(profileDao.GetPassword(Arg<string>.Is.Equal("joey"))).Return("91");
            Expect.Call(rsaToken.GetRandom(Arg<string>.Is.Equal("joey"))).Return("000000");
            Expect.Call(delegate { logger.Log(Arg<string>.Is.Anything); });
            mocks.ReplayAll();

            Assert.IsFalse(authenticationService.IsValid("joey", "incorrect"));
        }

        [Test]
        public void invalid_withlog()
        {
            Expect.Call(profileDao.GetPassword(Arg<string>.Is.Equal("joey"))).Return("91");
            Expect.Call(rsaToken.GetRandom(Arg<string>.Is.Equal("joey"))).Return("000000");
            Expect.Call(delegate { logger.Log(Arg<string>.Is.Equal("account: joey login failed")); });

            mocks.ReplayAll();

            authenticationService.IsValid("joey", "incorrect");

            mocks.VerifyAll();
        }
    }
}
