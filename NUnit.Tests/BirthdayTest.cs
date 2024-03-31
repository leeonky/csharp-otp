using System;
using NUnit.Framework;
using csharp_otp;
using Rhino.Mocks;

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
            
            MockRepository mocks = new MockRepository();
            Today stubToday = mocks.Stub<Today>();
            Expect.Call(stubToday.GetToday()).Return(DateTime.Parse("2002-04-09"));
            mocks.ReplayAll();

            Birthday birthday = new Birthday(stubToday);

            Assert.IsTrue(birthday.IsBirthday());
        }

        [Test]
        public void is_not_birthday()
        {
            //StubToday stubToday = new StubToday();
            //stubToday.SetToday("2002-05-20");

            MockRepository mocks = new MockRepository();
            Today stubToday = mocks.Stub<Today>();
            Expect.Call(stubToday.GetToday()).Return(DateTime.Parse("2002-05-20"));
            mocks.ReplayAll();

            Birthday birthday = new Birthday(stubToday);

            Assert.IsFalse(birthday.IsBirthday());
        }
    }
}
