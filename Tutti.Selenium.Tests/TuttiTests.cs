using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Tutti.Selenium.Tests
{
    [TestClass]
    public class TuttiTests
    {

        public static Tutti client;
        public static readonly string Username = "...";
        public static readonly string Password = "...";

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext textContext)
        {
            var options = new ChromeOptions();
            options.AddExtensions(GetResourceFilePath("CookiesPlugin.crx"));

            var driver = new ChromeDriver(options);
            client = new Tutti(driver);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            client.Models.GetDriver().Quit();
        }
        public static string GetResourceFilePath(string filename)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(path, "Resources", filename);
        }
    }
}
