using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_otp
{
    public class Birthday
    {
        public bool IsBirthday()
        {
            DateTime now = DateTime.Now;
            return now.Month == 4 && now.Day == 9;
        }
    }
}
