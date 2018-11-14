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

        public int GetGroupsCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCashe = null;

        public List<GroupData> GetGroupsList()
        {
            if(groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(null)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }

                string allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupsNames.Split('\n');
                int shift = groupCashe.Count - parts.Length;
                for (int i = 0; i < groupCashe.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCashe[i].Name = "";
                    }
                    else
                    {
                        groupCashe[i].Name = parts[i-shift].Trim();
                    }
                }
            }
            return new List<GroupData>(groupCashe);
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
            groupCashe = null;
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
            groupCashe = null;
        }
        
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCashe = null;
        }

        public bool IsGroupExists()
        {
            return IsElementPresent(By.ClassName("group"));
        }
    }
}
