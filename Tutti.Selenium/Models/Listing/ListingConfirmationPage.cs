using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;

namespace Tutti.Selenium.Models
{
    public class ListingConfirmationPage : BasePage
    {
        public ListingConfirmationPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@id='aiSubmitFree']")]
        IWebElement ConfirmButton;

        public void ClickSubmitButton()
        {
            Click(ConfirmButton);

            // thank you page...
        }
    }
}
