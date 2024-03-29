using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_otp
{
    public class Today
    {
        virtual public DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}
