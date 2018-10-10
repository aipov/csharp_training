using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("James");
            newData.Middlename = "TIM";
            newData.Lastname = "10oct";
            newData.Title = "Agent";
            newData.Company = "Apple";
            newData.Address = "California";
            newData.Mobile = "+55555555555";
            newData.Work = "+10008888888";
            newData.Email = "test@mail.com";
            newData.Homepage = "apple.com";
            newData.Address2 = "San-Francisco";
            newData.Notes = "comments";

            app.Contacts.Modify(1, newData);
        }

    }
}
