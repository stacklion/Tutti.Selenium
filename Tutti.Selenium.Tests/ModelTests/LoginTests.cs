using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tutti.Selenium.Tests.ModelTests
{
    [TestClass]
    public class LoginTests : BaseTests
    {
        [TestInitialize]
        public void Initialize()
        {
            // Make sure we are not logged in
            ClearCookies();

            // Go to web page
            client.Models.Login.GoToPage();
        }

        [TestMethod]
        public void EnterEmail()
        {
            client.Models.Login.EnterEmail("admin@gmail.com");
        }

        [TestMethod]
        public void EnterPassword()
        {
            client.Models.Login.EnterPassword("password123");
        }

        [TestMethod]
        public void ClickLogin()
        {
            client.Models.Login.ClickLogin();
        }

    }
}
