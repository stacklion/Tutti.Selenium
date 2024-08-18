using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Tutti.Selenium.Models
{
    public class MyAdsActivePage : BasePage
    {
        public MyAdsActivePage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            Url = new Uri("https://www.tutti.ch/de/myads/active");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[2]/div/span[2]")]
        private IWebElement MarketplaceListings;

        [FindsBy(How = How.XPath, Using = "//div[2]/div/div/div/div[2]/a")]
        private IList<IWebElement> ActiveListings;

        public int GetListingsCount()
        {
            return Convert.ToInt32(MarketplaceListings.Text.Split('/')[0].Trim());
        }

        public int GetListingsLimit()
        {
            return Convert.ToInt32(MarketplaceListings.Text.Split('/')[1].Trim());
        }

        public IEnumerable<Uri> GetActiveListings()
        {
           foreach(var link in ActiveListings)
           {
               yield return new Uri(link.GetAttribute("href"));
           }
        }
    }
}
