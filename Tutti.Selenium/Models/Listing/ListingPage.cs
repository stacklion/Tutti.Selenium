using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Tutti.Selenium.Models
{
    public class ListingPage : BasePage
    {
        public ListingPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SetUrl(Uri url)
        {
            Url = url;
        }

        [FindsBy(How = How.XPath, Using = "//div[2]/img")]
        private IList<IWebElement> Pictures;

        [FindsBy(How = How.XPath, Using = "//h1")]
        private IWebElement Title;

        [FindsBy(How = How.XPath, Using = "//tr[2]/td")]
        private IWebElement Description;

        [FindsBy(How = How.XPath, Using = "//td/div/a")]
        private IWebElement Category;

        [FindsBy(How = How.XPath, Using = "//dd")]
        private IWebElement ListingType;

        [FindsBy(How = How.XPath, Using = "//tr[4]/td/dd")]
        private IWebElement ZipCode;

        [FindsBy(How = How.XPath, Using = "//tr[4]/td[2]/dd")]
        private IWebElement District;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement Price;

        [FindsBy(How = How.XPath, Using = "//div[2]/span")]
        private IWebElement Views;


        public IEnumerable<Uri> GetPicturePaths()
        {
            foreach (var pic in Pictures)
            {
                yield return new Uri(pic.GetAttribute("src"));
            }
        }

        public string GetTitle()
        {
            return Title.Text;
        }

        public string GetDescription()
        {
            return Description.Text;
        }

        public string GetCategory()
        {
            return Category.Text;
        }

        public string GetListingType()
        {
            return ListingType.Text;
        }

        public int GetZipCode()
        {
            return Convert.ToInt32(ZipCode.Text);
        }

        public string GetCanton()
        {
            return District.Text;
        }

        public int GetPrice()
        {
            return Convert.ToInt32(Price.Text.Replace(".-", string.Empty));
        }

        public int GetViews()
        {
            return Convert.ToInt32(Views.Text);
        }


    }
}
