using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_otp
{
    public class AuthenticationService
    {
        private readonly ProfileDao profileDao;
        private readonly RsaToken rsaToken;
        private readonly Logger logger;

        public AuthenticationService(ProfileDao profileDao, RsaToken rsaToken, Logger logger)
        {
            this.profileDao = profileDao;
            this.rsaToken = rsaToken;
            this.logger = logger;
        }

        public bool IsValid(string userName, string password)
        {
            string passwordFromDao = profileDao.GetPassword(userName);
            string randomCode = rsaToken.GetRandom(userName);
            string validPassword = passwordFromDao + randomCode;

            bool isValid = password == validPassword;

            if (isValid)
            {
                return true;
            }
            else
            {
                logger.Log("account: " + userName + " login failed");
                return false;
            }
        }
    }
}
