using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCBank.Controllers;
using System.Web.Mvc;

namespace MVCBank.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private HomeController homeController;

        public UnitTest1()
        {
            this.homeController = new HomeController();
        }
        [TestMethod]
        public void FooActionReturnsAboutView()
        {
            var result = this.homeController.Foo() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }


    }
}
