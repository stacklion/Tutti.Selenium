using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tutti.Selenium.Controllers;

namespace Tutti.Selenium.Tests.ControllerTests
{
    [TestClass]
    public class ListingTests : BaseTests
    {

        private readonly Uri ListingUrl;

        private Listing Listing
        {
            get
            {
                return listing ?? GetListing();
            }
            set
            {
                listing = value;
            }
        }

        private Listing listing;

        private Listing GetListing()
        {
            Listing = client.Listing(ListingUrl);
            return Listing;
        }


        public ListingTests() : base()
        {
            ListingUrl = new Uri("https://www.tutti.ch/de/vi/zuerich/kleidung-accessoires/kleidung-fuer-herren/diesel-lederjacke-l/43508356");
        }

        [TestMethod]
        public void ValidateListing()
        {
            Assert.IsNotNull(Listing);
        }

    }
}
