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
            private string dateStr;

            public void SetToday(string dateStr)
            {
                this.dateStr = dateStr;
            }

            override public DateTime GetToday()
            {
                return DateTime.Parse(this.dateStr);
            }
        }

        [Test]
        public void is_birthday()
        {
            StubToday stubToday = new StubToday();
            stubToday.SetToday("2002-04-09");

            Birthday birthday = new Birthday(stubToday);

            Assert.IsTrue(birthday.IsBirthday());
        }

        [Test]
        public void is_not_birthday()
        {
            StubToday stubToday = new StubToday();
            stubToday.SetToday("2002-05-20");

            Birthday birthday = new Birthday(stubToday);

            Assert.IsFalse(birthday.IsBirthday());
        }
    }
}
