using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Selenium.Humanize.Models;

namespace Tutti.Selenium.Models
{
    public class ListingDescriptionPage : BasePage
    {
        public ListingDescriptionPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random) 
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='zipcode']")]
        private IWebElement ZipCodeInput;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[2]/div/div/div/div")]
        private IWebElement CantonDropdown;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[2]/div/div/div/div/div[2]/div/span")]
        private IList<IWebElement> CantonDropdownItems;

        [FindsBy(How = How.XPath, Using = "//input[@name='price']")]
        private IWebElement PriceInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='cb_free_ad']")]
        private IWebElement IsFreeCheckbox;

        [FindsBy(How = How.XPath, Using = "//input[@name='subject']")]
        private IWebElement SubjectInput;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='textarea_body']")]
        private IWebElement DescriptionInput;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        IWebElement NextButton;

        public void EnterZipCode(int zipCode)
        {
            Clear(ZipCodeInput);
            SendKeys(ZipCodeInput, zipCode.ToString());
        }

        public void ChooseCanton(string canton)
        {
            // Click it
            Click(CantonDropdown);

            // Choose element from dropdown
            var targetCanton = CantonDropdownItems.Where(ctn => ctn.Text.Equals(canton)).FirstOrDefault();
            Click(targetCanton);
        }

        public void EnterPrice(int price)
        {
            SendKeys(PriceInput, price.ToString());
        }

        public void ClickIsFreeCheckbox()
        {
            Click(IsFreeCheckbox);
        }

        public void EnterSubject(string subject)
        {
            SendKeys(SubjectInput, subject);
        }

        public void EnterDescription(string description)
        {
            SendKeys(DescriptionInput, description);
        }

        public ListingContactPage ClickNextButton()
        {
            Click(NextButton);

            return new ListingContactPage(ref Driver, ref Rnd);
        }
    }
}
