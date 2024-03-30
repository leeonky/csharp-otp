using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using csharp_otp;
using Rhino.Mocks;

namespace unit_test
{
    [TestFixture]
    class AuthenticationServiceTest
    {
        class StubProfileDao : ProfileDao
        {
            public override string GetPassword(string userName)
            {
                return password[userName];
            }

            private Dictionary<string,string> password = new Dictionary<string,string>();
            public Dictionary<string, string> Password { set { password = value; } get { return password; } }
        }

        class StubRsaToken : RsaToken
        {
            public override string GetRandom(string userName)
            {
                return random;
            }

            private string random;
            public string Random { set { random = value; } }
        }

        class MockLogger : Logger
        {
            public override void Log(string content)
            {
                stringBuider.AppendLine(content);
            }

            private StringBuilder stringBuider = new StringBuilder();

            public string getLog()
            {
                return stringBuider.ToString();
            }
        }

        StubProfileDao profileDao;
        StubRsaToken rsaToken;
        MockLogger logger;
        AuthenticationService authenticationService;

        [SetUp]
        public void SetUpAll()
        {
            profileDao = new StubProfileDao();
            rsaToken = new StubRsaToken();
            logger = new MockLogger();
            authenticationService = new AuthenticationService(profileDao, rsaToken, logger);
        }

        
        [Test]
        public void valid()
        {
            profileDao.Password["joey"] = "91";
            rsaToken.Random = "000000";

            Assert.IsTrue(authenticationService.IsValid("joey", "91000000"));
        }

        [Test]
        public void invalid()
        {
            profileDao.Password["joey"] = "91";
            rsaToken.Random = "000000";

            Assert.IsFalse(authenticationService.IsValid("joey", "incorrect"));
        }

        [Test]
        public void invalid_withlog()
        {
            profileDao.Password["joey"] = "91";
            rsaToken.Random = "000000";

            authenticationService.IsValid("joey", "incorrect");

            Assert.AreEqual("account: joey login failed\r\n", logger.getLog());
        }
    }
}
