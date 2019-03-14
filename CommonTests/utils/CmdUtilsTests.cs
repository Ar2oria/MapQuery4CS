using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.utils.Tests
{
    [TestClass()]
    public class CmdUtilsTests
    {
        [TestMethod()]
        public void RunCmdStandardTest()
        {
            CmdUtils.RunCmdStandard("ipconfig");
        }
    }
}