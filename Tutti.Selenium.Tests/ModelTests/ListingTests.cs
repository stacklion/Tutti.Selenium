using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tutti.Selenium.Models;

namespace Tutti.Selenium.Tests.ModelTests
{
    [TestClass]
    public class ListingTests : BaseTests
    {

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var url = new Uri("https://www.tutti.ch/de/vi/zuerich/kleidung-accessoires/kleidung-fuer-herren/diesel-lederjacke-l/43508356");

            // Go to web page
            client.Models.Listing.SetUrl(url);
            client.Models.Listing.GoToPage();
        }

        [TestMethod]
        public void GetPictures()
        {
            var pictures = client.Models.Listing.GetPicturePaths();

            Assert.IsNotNull(pictures);
            Assert.IsTrue(pictures.Count() >= 0);
        }

        [TestMethod]
        public void GetTitle()
        {
            var title = client.Models.Listing.GetTitle();

            Assert.IsFalse(string.IsNullOrWhiteSpace(title));
        }

        [TestMethod]
        public void GetDescription()
        {
            var description = client.Models.Listing.GetDescription();

            Assert.IsFalse(string.IsNullOrWhiteSpace(description));
        }

        [TestMethod]
        public void GetCategory()
        {
            var category = client.Models.Listing.GetCategory();

            Assert.IsFalse(string.IsNullOrWhiteSpace(category));
        }

        [TestMethod]
        public void GetListingType()
        {
            var listingType = client.Models.Listing.GetListingType();

            Assert.IsFalse(string.IsNullOrWhiteSpace(listingType));
        }

        [TestMethod]
        public void GetZipCode()
        {
            var zipCode = client.Models.Listing.GetZipCode();

            Assert.IsNotNull(zipCode);
            Assert.IsTrue(zipCode > 0);
        }

        [TestMethod]
        public void GetCanton()
        {
            var canton = client.Models.Listing.GetCanton();

            Assert.IsFalse(string.IsNullOrWhiteSpace(canton));
        }

        [TestMethod]
        public void GetPrice()
        {
            var price = client.Models.Listing.GetPrice();

            Assert.IsNotNull(price);
            Assert.IsTrue(price >= 0);
        }

        [TestMethod]
        public void GetViews()
        {
            var views = client.Models.Listing.GetViews();

            Assert.IsNotNull(views);
            Assert.IsTrue(views >= 0);
        }
    }
}
