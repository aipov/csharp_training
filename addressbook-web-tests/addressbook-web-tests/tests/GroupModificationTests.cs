using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("val");
            newData.Header = "m02";
            newData.Footer = "m03";
            app.Groups.Modify(1, newData);
        }
    }
}
