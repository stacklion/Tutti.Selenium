using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;


namespace Tutti.Selenium.Models
{
    public class HomePage : BasePage
    {

        public HomePage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            Url = new Uri("https://www.tutti.ch/");
            PageFactory.InitElements(driver, this);
        }


    }
}
