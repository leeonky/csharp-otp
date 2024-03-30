using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_otp
{
    public class Logger
    {
        public
#if TEST
            virtual        
#endif
            void Log(string content)
        {
            Console.WriteLine(content);
        }
    }
}
