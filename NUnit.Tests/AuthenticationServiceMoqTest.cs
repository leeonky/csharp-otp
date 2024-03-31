using NUnit.Framework;
using csharp_otp;
using Moq;

namespace unit_test
{
    [TestFixture]
    class AuthenticationServiceMoqTest
    {
        Mock<ProfileDao> profileDao;
        Mock<RsaToken> rsaToken;
        Mock<Logger> logger;
        AuthenticationService authenticationService;

        [SetUp]
        public void SetUpAll()
        {
            profileDao = new Mock<ProfileDao>();
            rsaToken = new Mock<RsaToken>();
            logger = new Mock<Logger>();
            authenticationService = new AuthenticationService(profileDao.Object, rsaToken.Object, logger.Object);
        }
        
        [Test]
        public void valid()
        {
            profileDao.Setup(p => p.GetPassword("joey")).Returns("91");
            rsaToken.Setup(r => r.GetRandom("joey")).Returns("000000");

            Assert.IsTrue(authenticationService.IsValid("joey", "91000000"));
        }

        [Test]
        public void invalid()
        {
            profileDao.Setup(p => p.GetPassword("joey")).Returns("91");
            rsaToken.Setup(r => r.GetRandom("joey")).Returns("000000");

            Assert.IsFalse(authenticationService.IsValid("joey", "incorrect"));
        }

        [Test]
        public void invalid_withlog()
        {
            profileDao.Setup(p => p.GetPassword("joey")).Returns("91");
            rsaToken.Setup(r => r.GetRandom("joey")).Returns("000000");

            authenticationService.IsValid("joey", "incorrect");

            logger.Verify(l => l.Log("account: joey login failed"));
        }
    }
}
