using NUnit.Framework;
using csharp_otp;
using Moq;
using System;

namespace unit_test
{
    [TestFixture]
    class BirthdayTest
    {
        /*
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
        }*/

        [Test]
        public void is_birthday()
        {
            //StubToday stubToday = new StubToday();
            //stubToday.SetToday("2002-04-09");

            Mock<Today> stubToday = new Mock<Today>();
            stubToday.Setup(today => today.GetToday()).Returns(new DateTime(2002, 4, 9));

            Birthday birthday = new Birthday(stubToday.Object);

            Assert.IsTrue(birthday.IsBirthday());
        }

        [Test]
        public void is_not_birthday()
        {
            //StubToday stubToday = new StubToday();
            //stubToday.SetToday("2002-05-20");

            Mock<Today> stubToday = new Mock<Today>();
            stubToday.Setup(today => today.GetToday()).Returns(new DateTime(2002, 5, 20));

            Birthday birthday = new Birthday(stubToday.Object);

            Assert.IsFalse(birthday.IsBirthday());
        }
    }
}
