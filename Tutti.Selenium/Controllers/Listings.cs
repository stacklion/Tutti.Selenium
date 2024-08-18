using System;
using System.Collections.Generic;
using System.Text;

namespace Tutti.Selenium.Controllers
{
    /// <summary>
    /// Listings
    /// Require authenticated user
    /// </summary>
    public class Listings : BaseController
    {
        internal Dispatch Dispatch;

        public Listings(Dispatch dispatch)
        {
            Dispatch = dispatch;
        }

        public void CreateListing(string category, string subcategory, string type, IEnumerable<string> picturePaths,
            int zipCode, string canton, int price, string subject,
            string description, bool isPrivateNumber, string phoneNumber, bool hidePhoneNumber)
        {
            Dispatch.StartListing.GoToPage();
            Dispatch.StartListing.ChooseCategory(category);
            Dispatch.StartListing.ChooseSubcategory(subcategory);
            Dispatch.StartListing.ChooseType(type);

            // TODO limit amount?
            foreach(var path in picturePaths)
                Dispatch.StartListing.UploadPicture(path);

            var descriptionPage = Dispatch.StartListing.ClickNextButton();
            descriptionPage.WaitForChanges();
            descriptionPage.EnterZipCode(zipCode);
            descriptionPage.ChooseCanton(canton);

            if (type.Equals("Angebote"))
            {
                if (price == 0)
                    descriptionPage.ClickIsFreeCheckbox();
                else
                    descriptionPage.EnterPrice(price);
            }
            
            descriptionPage.EnterSubject(subject);
            descriptionPage.EnterDescription(description);

            var contactPage = descriptionPage.ClickNextButton();
            contactPage.WaitForChanges();

            if (isPrivateNumber)
                contactPage.ClickPrivateSelect();
            else
                contactPage.ClickCompanySelect();

            contactPage.EnterPhoneNumber(phoneNumber);

            if(!hidePhoneNumber)
                contactPage.ClickHidePhoneNumberCheckbox();

            var previewPage = contactPage.ClickNextButton();
            previewPage.WaitForChanges();
            var confirmPage = previewPage.ClickNextButton();
            confirmPage.WaitForChanges();

            confirmPage.ClickSubmitButton();
            confirmPage.WaitForChanges();
        }

        public IEnumerable<Listing> GetActiveListings()
        {
            Dispatch.MyAds.GoToPage();

            foreach (var listing in Dispatch.MyAds.GetActiveListings())
            {
                yield return new Listing(Dispatch, listing);
            }
        }
    }
}
