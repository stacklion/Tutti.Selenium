using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;

namespace Tutti.Selenium.Models
{
    public class ListingPreviewPage : BasePage
    {
        public ListingPreviewPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        IWebElement NextButton;

        public ListingConfirmationPage ClickNextButton()
        {
            Click(NextButton);

            return new ListingConfirmationPage(ref Driver, ref Rnd);
        }
    }
}
