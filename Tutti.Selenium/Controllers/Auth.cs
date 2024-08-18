using System;

namespace Tutti.Selenium.Controllers
{
    /// <summary>
    /// Auth Logic
    /// What counts as logged in? Successfully registered? What does not?
    /// </summary>
    public class Auth : BaseController
    {
        internal Dispatch Dispatch;
     
        public Auth(Dispatch dispatch)
        {
            Dispatch = dispatch;
        }

        /// <summary>
        /// Check cookies for authentication
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            var driver = Dispatch.GetDriver();

            // Check cookies
            var mpSessionId = driver.Manage().Cookies.GetCookieNamed("mp_session_id");
            var mpSession = driver.Manage().Cookies.GetCookieNamed("mp_session");
            var mpAccountInfo = driver.Manage().Cookies.GetCookieNamed("mp_account_info");
            var mpAccountNa = driver.Manage().Cookies.GetCookieNamed("mp_account_na");
            var adw = driver.Manage().Cookies.GetCookieNamed("adw");

            return mpSessionId != null &&
                mpSession != null &&
                mpAccountInfo != null &&
                mpAccountNa != null &&
                adw != null;
        }

        /// <summary>
        /// Login and check status
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Login(string email, string password)
        {
            Dispatch.Login.GoToPage();
            Dispatch.Login.EnterEmail(email);
            Dispatch.Login.EnterPassword(password);
            Dispatch.Login.ClickLogin();

            // Wait for changes to happen
            Dispatch.Login.WaitForChanges();

            // Wrong credentials
            if (Dispatch.Login.GetSourceCode().Contains("Die E-Mail-Adresse oder das Passwort ist ungültig."))
                throw new Exception("Login failed, wrong credentials");

            // Mail Confirm
            if (Dispatch.Login.GetSourceCode().Contains("Bitte überprüfe deinen Posteingang und klicke auf den Link, den wir dir gesendet haben, um dein Konto zu aktivieren."))
                throw new Exception("Login failed, mail confirmation needed");

            // Cookie check
            if(!IsLoggedIn())
            {
                throw new Exception("Login failed, unknown error");
            }
        }
        
        /// <summary>
        /// Register and check status
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void Register(string email, string password)
        {
            Dispatch.Login.GoToPage();

            var registerPage = Dispatch.Login.ClickRegisterLink();

            registerPage.EnterEmail(email);
            registerPage.EnterPassword(password);
            registerPage.EnterPasswordConfirmation(password);

            var loginPage = registerPage.ClickRegister();

            // Wait for changes to happen
            loginPage.WaitForChanges();

            // Already registered
            if (Dispatch.Login.GetSourceCode().Contains("Auf diese E-Mail-Adresse ist bereits ein Konto registriert."))
                throw new Exception("Registration failed, occupied mail address");

            // Password dont match
            if (Dispatch.Login.GetSourceCode().Contains("Die eingegebenen Passwörter stimmen nicht überein."))
                throw new Exception("Registration failed, passwords do not match");

            // Validate our stuff
            if (!loginPage.GetSourceCode().Contains("Bitte überprüfe deinen Posteingang und klicke auf den Link, den wir dir gesendet haben, um dein Konto zu aktivieren"))
                throw new Exception("Registration failed, unknown error");

        }

    }
}
