using System.Web.Mvc;

namespace MvcOktaExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Account()
        {
            return View();
        }
    }
}