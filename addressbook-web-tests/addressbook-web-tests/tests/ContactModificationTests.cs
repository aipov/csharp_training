using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.VerificationContactExists();

            ContactData newData = new ContactData("James");
            newData.Middlename = "TIM";
            newData.Lastname = null;
            newData.Title = "Agent";
            newData.Company = "Apple";
            newData.Address = "California";
            newData.Mobile = null;
            newData.Work = "+10008888888";
            newData.Email = null;
            newData.Homepage = null;
            newData.Address2 = null;
            newData.Notes = null;

            app.Contacts.Modify(0, newData);
        }

    }
}
