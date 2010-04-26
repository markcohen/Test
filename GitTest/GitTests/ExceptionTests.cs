﻿using System;
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
