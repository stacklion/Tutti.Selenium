using OpenQA.Selenium;
using Selenium.Humanize.Models;
using System;

namespace Tutti.Selenium.Controllers
{
    public class Dispatch : BaseController
    {

        #region Endpoints (direct access by url)

        public Models.HomePage Home { get; set; }
        public Models.LoginPage Login { get; set; }
        public Models.MyAdsActivePage MyAds { get; set; }
        public Models.ListingStartPage StartListing { get; set; }
        public Models.ListingPage Listing { get; set; }

        #endregion

        internal IWebDriver Driver;
        internal Random Rnd;

        public IWebDriver GetDriver()
        {
            return Driver;
        }


        public Dispatch(IWebDriver driver, Random random)
        {
            this.Driver = driver;
            this.Rnd = random;

            Login = new Models.LoginPage(ref Driver, ref Rnd);
            MyAds = new Models.MyAdsActivePage(ref Driver, ref Rnd);
            StartListing = new Models.ListingStartPage(ref Driver, ref Rnd);
            Listing = new Models.ListingPage(ref Driver, ref Rnd);
        }


    }
}
