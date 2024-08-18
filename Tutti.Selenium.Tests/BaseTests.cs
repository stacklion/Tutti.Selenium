using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tutti.Selenium.Tests
{
    /// <summary>
    /// Implementation used by Tests
    /// </summary>
    public abstract class BaseTests
    {
        private TestContext TestContextInstance;

        public TestContext TestContext
        {
            get
            {
                return TestContextInstance;
            }
            set
            {
                TestContextInstance = value;
            }
        }

        public static Tutti client => TuttiTests.client;

        public BaseTests() { }

        public void ClearCookies()
        {
            client.Models.GetDriver().Manage().Cookies.DeleteAllCookies();
        }

        public void VisitGoogle()
        {
            client.Models.GetDriver().Navigate().GoToUrl("https://google.com");
        }

        protected string GetResourceFilePath(string filename)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(path, "Resources", filename);
        }

    }
}
