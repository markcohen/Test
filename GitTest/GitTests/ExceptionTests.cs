using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitTests
{
    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUserInterfaceException()
        {
            throw new ApplicationException("TestUserInterfaceException");
        }
    }
}
