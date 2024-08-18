using Bogus;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutti.Selenium.Tests.ControllerTests
{
    [TestClass]
    public class AuthTests : BaseTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ClearCookies();
        }

        [TestMethod]
        public void Login()
        {
            client.Auth.Login(TuttiTests.Username, TuttiTests.Password);
        }

        [TestMethod]
        public void Register()
        {
            var internet = new Internet();
            client.Auth.Register(internet.Email(), internet.Password());
        }

    }
}
