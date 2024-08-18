using System;
using System.Collections.Generic;

namespace Tutti.Selenium.Controllers
{
    /// <summary>
    /// Single listing
    /// </summary>
    public class Listing : BaseController
    {
        internal Dispatch Dispatch;

        /// <summary>
        /// Urls of all pictures
        /// </summary>
        public IEnumerable<Uri> Pictures { get; set; }

        /// <summary>
        /// Title of the listing
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the listing
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Listing type
        /// </summary>
        public string ListingType { get; set; }

        /// <summary>
        /// Swiss Zip Code
        /// </summary>
        public int ZipCode { get; set; }

        /// <summary>
        /// District of the owner
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// Price of the listing
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Views of the listing
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Underlying url, instead of api endpoint response (Things)
        /// Reference data point
        /// </summary>
        private Uri Url { get; set; }


        public Listing(Dispatch dispatch)
        {
            Dispatch = dispatch;
        }

        public Listing(Dispatch dispatch, Uri url)
        {
            Dispatch = dispatch;
            Import(url);
        }

        private void Import(Uri url)
        {
            Url = url;

            var listingPage = Dispatch.Listing;
            listingPage.SetUrl(url);
            listingPage.GoToPage();

            // Load stuff
            Pictures = listingPage.GetPicturePaths();
            Title = listingPage.GetTitle();
            Description = listingPage.GetDescription();
            ListingType = listingPage.GetListingType();
            ZipCode = listingPage.GetZipCode();
            District = listingPage.GetDescription();
            Price = listingPage.GetPrice();
            Views = listingPage.GetViews();
        }

    }
}
