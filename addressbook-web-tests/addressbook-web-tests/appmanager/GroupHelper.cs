using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {}

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupsList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
            
        }

        public void VerificationGroupExists()
        {
            manager.Navigator.GoToGroupsPage();
            if (IsGroupExists())
            { }
            else
            {
                GroupData group = new GroupData("10oct");
                group.Header = "g22";
                group.Footer = "g33";
                Create(group);
            }
        }

        //низкоуровневые методы
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + (index+1) + "]/input")).Click();
        }

        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
        }

        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
        }

        public void SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
        }
        
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }

        public bool IsGroupExists()
        {
            return IsElementPresent(By.ClassName("group"));
        }
    }
}
