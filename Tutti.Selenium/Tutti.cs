using OpenQA.Selenium;
using System;
using Tutti.Selenium.Controllers;

namespace Tutti.Selenium
{
    public class Tutti
    {
        /// <summary>
        /// Endpoint wrapper
        /// </summary>
        public Dispatch Models;

        /// <summary>
        /// Prepare our library for use
        /// </summary>
        /// <param name="driver"></param>
        public Tutti(IWebDriver driver)
        {
            var random = new Random();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Models = new Dispatch(driver, random);
        }

        #region Controllers (Logic Instances)

        public Auth Auth
        {
            get
            {
                return new Auth(Models);
            }
        }

        public Account Account
        {
            get
            {
                return new Account(Models);
            }
        }

        public Listing Listing(Uri url)
        {
            return new Listing(Models, url);
        }

        #endregion
    }
}
