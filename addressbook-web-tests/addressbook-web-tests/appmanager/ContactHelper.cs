using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        { }
        
        public ContactHelper Create(ContactData contact)
        {
            manager.Contacts.InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        internal ContactData GetInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homephone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilephone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workphone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Home = homephone,
                Mobile = mobilephone,
                Work = workphone
            };
        }

        internal ContactData GetInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public List<ContactData> GetContactsList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
            foreach (IWebElement element in elements)
            {
                var cells = element.FindElements(By.CssSelector("td"));
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            manager.Contacts.SelectContact(v);
            RemoveContact();
            return this;
        }

        public void VerificationContactExists()
        {
            manager.Navigator.GoToHomePage();
            if (IsContactExists())
            { }
            else
            {
                ContactData contact = new ContactData("Temp", "");
                contact.Middlename = "temporary";
                Create(contact);
            }
        }
        //низкоуровневые методы
        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
        }
        
        public void SubmitContactCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
        }

        private void SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
        }

        public void SelectContact(int v)
        {
            driver.FindElement(By.CssSelector("input[type='checkbox']")).Click();
        }

        private void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        private bool IsContactExists()
        {
            return IsElementPresent(By.TagName("td"));
        }
    }
}
