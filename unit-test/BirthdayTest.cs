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

        public class StubToday : Today
        {
            override public DateTime GetToday()
            {
                return DateTime.Parse("2002-04-09");
            }
        }

        [Test]
        public void is_birthday()
        {
            Birthday birthday = new Birthday(new StubToday());
            Assert.IsTrue(birthday.IsBirthday());
        }
    }
}
