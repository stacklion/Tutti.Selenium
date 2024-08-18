using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutti.Selenium.Tests.ModelTests.Workflow
{
    [TestClass]
    public class MyAdsActiveTests : BaseTests
    {


        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            if (!client.Auth.IsLoggedIn())
                client.Auth.Login(TuttiTests.Username, TuttiTests.Password);

            client.Models.MyAds.GoToPage();
        }

        [TestMethod]
        public void GetListingsCount()
        {
            var listingsCount = client.Models.MyAds.GetListingsCount();

            Assert.IsNotNull(listingsCount);
            Assert.IsTrue(listingsCount >= 0);
        }

        [TestMethod]
        public void GetListingsLimit()
        {
            var listingsLimit = client.Models.MyAds.GetListingsLimit();

            Assert.IsNotNull(listingsLimit);
            Assert.IsTrue(listingsLimit >= 200);
        }

        [TestMethod]
        public void GetActiveListings()
        {
            var activeListings = client.Models.MyAds.GetActiveListings();

            Assert.IsNotNull(activeListings);
        }
    }
}
