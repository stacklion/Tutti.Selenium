
namespace Tutti.Selenium.Controllers
{
    public class Account : BaseController
    {
        internal Dispatch Dispatch;

        public Listings Listings
        {
            get
            {
                return new Listings(Dispatch);
            }
        }


        public Account(Dispatch dispatch)
        {
            Dispatch = dispatch;
        }
    }
}
