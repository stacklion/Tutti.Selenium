using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;

namespace Tutti.Selenium.Models
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement EmailInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='passwordConfirmation']")]
        private IWebElement PasswordConfirmationInput;

        [FindsBy(How = How.XPath, Using = "//button[@type=\"submit\"]")]
        private IWebElement RegisterButton;

        public void EnterEmail(string email)
        {
            SendKeys(EmailInput, email);
        }

        public void EnterPassword(string password)
        {
            SendKeys(PasswordInput, password);
        }

        public void EnterPasswordConfirmation(string password)
        {
            SendKeys(PasswordConfirmationInput, password);
        }

        public LoginPage ClickRegister()
        {
            Click(RegisterButton);

            return new LoginPage(ref Driver, ref Rnd);
        }


    }
}
