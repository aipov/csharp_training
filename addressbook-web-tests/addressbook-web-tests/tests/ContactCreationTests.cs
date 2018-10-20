using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("James");
            contact.Middlename = "007";
            contact.Lastname = "10oct";
            contact.Title = "Agent";
            contact.Company = "Gazprom";
            contact.Address = "Moscow";
            contact.Mobile = "+79001002030";
            contact.Work = "+1000200555";
            contact.Email = "test@mail.com";
            contact.Homepage = "gazprom.facebook.com";
            contact.Address2 = "London";
            contact.Notes = "Special";

            app.Contacts.Create(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Email = "";
            contact.Homepage = "";
            contact.Address2 = "";
            contact.Notes = "";

            app.Contacts.Create(contact);
        }
    }
}
