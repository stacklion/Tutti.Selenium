using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tutti.Selenium.Tests.ControllerTests.Workflow
{
    [TestClass]
    public class ListingsTest : BaseTests
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            if (!client.Auth.IsLoggedIn())
                client.Auth.Login(TuttiTests.Username, TuttiTests.Password);
        }

        [TestMethod]
        public void CreateListing()
        {
            client.Account.Listings.CreateListing(
                category: "Telefon & Navigation", 
                subcategory: "Handys", 
                type: "Gesuche",
                picturePaths: new List<string> { GetResourceFilePath("iphone12.png") },
                zipCode: 8000,
                canton: "Zürich",
                price: 500,
                subject: "Suche iPhone 12 Pro 256GB",
                description: @"Hallo, ich suche ein iPhone 12 Pro 256GB, kann abgeholt werden oder per Post.",
                isPrivateNumber: true,
                phoneNumber: "0792312355",
                hidePhoneNumber: true);
        }

        [TestMethod]
        public void GetActiveListings()
        {
            var listings = client.Account.Listings.GetActiveListings();

            Assert.IsNotNull(listings);
        }

    }
}
