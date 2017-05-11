using System.Web.Mvc;

namespace AddressBookFrontEnd.Controllers
{
    public class AddressBookController : Controller
    {
        // GET: Address
        [Route("AddressBook/GetAddressBook")]
        public ActionResult GetAddressBook()
        {
            return View("GetAddressBook");
        }
    }
}