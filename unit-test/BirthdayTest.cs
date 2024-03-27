using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using csharp_otp;

namespace unit_test
{
    [TestFixture]
    class BirthdayTest
    {
        [Test]
        public void is_birthday()
        {
            Birthday birthday = new Birthday();
            Assert.IsTrue(birthday.IsBirthday());
        }
    }
}
