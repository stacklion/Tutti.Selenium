using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using Selenium.Humanize.Models;

namespace Tutti.Selenium.Models
{
    public class ListingContactPage : BasePage
    {
        public ListingContactPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random) 
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[@id='form-radio-company_ad']/div/div/label")]
        private IWebElement PrivateSelect;

        [FindsBy(How = How.XPath, Using = "//div[@id='form-radio-company_ad']/div/div[2]/label")]
        private IWebElement CompanySelect;

        [FindsBy(How = How.XPath, Using = "//input[@name='phone']")]
        private IWebElement PhoneInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='cb_phone_hidden']")]
        private IWebElement HidePhoneCheckbox;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement NextButton;

        public void ClickPrivateSelect()
        {
            Click(PrivateSelect);
        }

        public void ClickCompanySelect()
        {
            Click(CompanySelect);
        }

        public void EnterPhoneNumber(string phoneNumber)
        {
            Clear(PhoneInput);

            SendKeys(PhoneInput, phoneNumber);
        }

        public void ClickHidePhoneNumberCheckbox()
        {
            Click(HidePhoneCheckbox);
        }

        public ListingPreviewPage ClickNextButton()
        {
            Click(NextButton);

            return new ListingPreviewPage(ref Driver, ref Rnd);
        }
    }
}
