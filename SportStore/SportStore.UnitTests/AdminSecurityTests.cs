using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SportStore.WebUI.Controllers;
using SportStore.WebUI.Infrastructure.Abstract;
using SportStore.WebUI.Models;
using System.Web.Mvc;
using Moq;

namespace SportStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credential()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            LoginViewModel model = new LoginViewModel
            {
                Username = "admin",
                Password = "secret"
            };

            AccountController target = new AccountController(mock.Object);

            ActionResult result = target.Login(model, "/MyURL");

            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_invalid_Credential()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("baduser", "badpass")).Returns(false);

            LoginViewModel model = new LoginViewModel
            {
                Username = "baduser",
                Password = "badpass"
            };

            AccountController target = new AccountController(mock.Object);

            ActionResult result = target.Login(model, "/MyURL");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
