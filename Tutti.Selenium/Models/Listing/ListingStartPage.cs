using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Selenium.Humanize.Models;

namespace Tutti.Selenium.Models
{
    public class ListingStartPage : BasePage
    {
        public ListingStartPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            Url = new Uri("https://www.tutti.ch/de/ai/start");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[1]/div/div/div")]
        private IWebElement CategoryDropdown;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[1]/div/div/div/div[2]/div/span")]
        private IList<IWebElement> CategoryDropdownItems;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[2]/div/div/div")]
        private IWebElement SubcategoryDropdown;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[2]/div/div/div/div[2]/div/span")]
        private IList<IWebElement> SubcategoryDropdownItems;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[3]/div/div/div")]
        private IWebElement TypeDropdown;

        [FindsBy(How = How.XPath, Using = "//form/div/div/div[2]/div[3]/div/div/div/div[2]/div/span")]
        private IList<IWebElement> TypeDropdownItems;

        [FindsBy(How = How.XPath, Using = "//input[@type='file']")]
        private IWebElement UploadedImagesInput;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        //button[@type='submit']

        private IWebElement NextButton;

      
        public void ChooseCategory(string category)
        {
            // Click it
            Click(CategoryDropdown);

            // Choose element from dropdown
            var targetCategory = CategoryDropdownItems.Where(ctg => ctg.Text.Equals(category)).FirstOrDefault();
            Click(targetCategory);
        }

        public void ChooseSubcategory(string subcategory)
        {
            // Click it
            Click(SubcategoryDropdown);

            // Choose element from dropdown
            var targetSubcategory = SubcategoryDropdownItems.Where(ctg => ctg.Text.Equals(subcategory)).FirstOrDefault();
            Click(targetSubcategory);
        }

        public void ChooseType(string type)
        {
            // Click it
            Click(TypeDropdown);

            // Choose element from dropdown
            var targetType = TypeDropdownItems.Where(ctg => ctg.Text.Equals(type)).FirstOrDefault();
            Click(targetType);
        }

        public void UploadPicture(string path)
        {
            UploadedImagesInput.SendKeys(path);
        }

        public ListingDescriptionPage ClickNextButton()
        {
            Click(NextButton);

            return new ListingDescriptionPage(ref Driver, ref Rnd);
        }

       
    }
}
