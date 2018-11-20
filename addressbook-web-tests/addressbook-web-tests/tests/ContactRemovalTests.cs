﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.VerificationContactExists();
            List<ContactData> oldContacts = app.Contacts.GetContactsList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsList().Count);
            List<ContactData> newContacts = app.Contacts.GetContactsList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
