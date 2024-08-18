using OpenQA.Selenium;
using Selenium.Humanize.Models;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Tutti.Selenium.Models
{

    public class LoginPage : BasePage
    {
        public LoginPage(ref IWebDriver driver, ref Random random) : base(ref driver, ref random)
        {
            Url = new Uri("https://www.tutti.ch/de/start/login");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement EmailInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//button[@type=\"submit\"]")]
        private IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//p/a")]
        private IWebElement RegisterLink;

        public void EnterEmail(string email)
        {
            SendKeys(EmailInput, email);
        }

        public void EnterPassword(string password)
        {
            SendKeys(PasswordInput, password);
        }

        public void ClickLogin()
        {
            Click(LoginButton);
        }

        /// <summary>
        /// Sometimes browser redirects to login, so we just visit login and then go to login page
        /// </summary>
        /// <returns></returns>
        public RegisterPage ClickRegisterLink()
        {
            Click(RegisterLink);

            return new RegisterPage(ref Driver, ref Rnd);
        }

      

    }
}
