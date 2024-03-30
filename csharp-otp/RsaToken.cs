using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_otp
{
    public class RsaToken
    {
        public
#if TEST
            virtual
#endif
            string GetRandom(string userName)
        {
            return random.Next(1000000).ToString("D6");
        }
        private Random random = new Random();
    }
}
