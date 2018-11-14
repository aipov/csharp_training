using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class TestConditions
    {
        [TestMethod]
        public void TestConditionIf()
            
        {
            int age = 58741;
            bool male = true;

            if (age >= 21 && age <100 && male)
            {
                System.Console.Write("man");
            }

            else if (age >= 21 && !male)
            {
                System.Console.Write("woman");
            }

            else if (age > 0 && age <= 21 &&  !male)
            {
                System.Console.Write("girl");
            }

            else if (age > 0 && age <= 21 && male)
            {
                System.Console.Write("boy");
            }

            else 
            {
                System.Console.Write("Please, check the age you've typed in.");
            }
            
        }
    }
}
