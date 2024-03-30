using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using csharp_otp;

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

        StubProfileDao profileDao = new StubProfileDao();
        StubRsaToken rsaToken = new StubRsaToken();
        Logger logger = new Logger();
        AuthenticationService authenticationService;

        public AuthenticationServiceTest()
        {
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
    }
}
