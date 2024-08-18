using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tutti.Selenium.Tests.ModelTests.Workflow
{
    [TestClass]
    public class ListingTests : BaseTests
    {
        [TestInitialize]
        public void Initialize()
        {
            if(!client.Auth.IsLoggedIn())
                client.Auth.Login(TuttiTests.Username, TuttiTests.Password);
        }

        [TestMethod]
        public void PostListing()
        {
            client.Models.StartListing.GoToPage();
            client.Models.StartListing.ChooseCategory("Telefon & Navigation");
            client.Models.StartListing.ChooseSubcategory("Handys");
            client.Models.StartListing.ChooseType("Gesuche");
            client.Models.StartListing.UploadPicture(GetResourceFilePath("iphone12.png"));

            var descriptionPage = client.Models.StartListing.ClickNextButton();
            descriptionPage.WaitForChanges();

            descriptionPage.EnterZipCode(8000);
            descriptionPage.ChooseCanton("Zürich");
            //descriptionPage.EnterPrice(500); // only on angebote..
            descriptionPage.EnterSubject("Suche iPhone 12 Pro 256GB");
            descriptionPage.EnterDescription(@"Hallo, ich suche ein iPhone 12 Pro 256GB, kann abgeholt werden oder per Post.");

            var contactPage = descriptionPage.ClickNextButton();
            contactPage.WaitForChanges();

            contactPage.ClickPrivateSelect();
            contactPage.EnterPhoneNumber("0798583322");

            var previewPage = contactPage.ClickNextButton();
            previewPage.WaitForChanges();
            var confirmPage = previewPage.ClickNextButton();
            confirmPage.WaitForChanges();

            confirmPage.ClickSubmitButton();
            confirmPage.WaitForChanges();
        }
    }
}
