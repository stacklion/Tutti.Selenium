using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tutti.Selenium.Models;

namespace Tutti.Selenium.Tests.ModelTests
{
    [TestClass]
    public class RegisterTests : BaseTests
    {
        RegisterPage registerPage;

        [TestInitialize]
        public void Initialize()
        {
            // Make sure we are not logged in
            ClearCookies();

            // Go to web page
            client.Models.Login.GoToPage();
            registerPage = client.Models.Login.ClickRegisterLink();
        }
        
        [TestMethod]
        public void EnterEmail()
        {
            registerPage.EnterEmail("admin@gmail.com");
        }

        [TestMethod]
        public void EnterPassword()
        {
            registerPage.EnterPassword("password123");
        }

        [TestMethod]
        public void EnterPasswordConfirmation()
        {
            registerPage.EnterPasswordConfirmation("password123");
        }

        [TestMethod]
        public void ClickRegister()
        {
            registerPage.ClickRegister();
        }

    }
}
