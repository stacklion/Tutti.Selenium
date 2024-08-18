using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tutti.Selenium.Tests.ControllerTests.Workflow
{
    [TestClass]
    public class AuthTests : BaseTests
    {
        [TestMethod]
        public void IsLoggedIn()
        {
            ClearCookies();
            Assert.IsFalse(client.Auth.IsLoggedIn());

            client.Auth.Login(TuttiTests.Username, TuttiTests.Password);
            Assert.IsTrue(client.Auth.IsLoggedIn());
        }
    }
}
