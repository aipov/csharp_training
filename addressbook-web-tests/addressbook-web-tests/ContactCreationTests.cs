using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("James");
            contact.Middlename = "007";
            contact.Lastname = "Bond";
            contact.Title = "Agent";
            contact.Company = "Gazprom";
            contact.Address = "Moscow";
            contact.Mobile = "+79001002030";
            contact.Work = "+1000200555";
            contact.Email = "test@mail.com";
            contact.Homepage = "gazprom.facebook.com";
            contact.Address2 = "London";
            contact.Notes = "Special";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }
    }
}
