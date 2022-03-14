using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using System.Web;
using System.Web.Mvc;

namespace MvcOktaExample.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated == false)
            {
                var properties = new AuthenticationProperties
                {
                    RedirectUri = "/Home/Account",     
                };

                HttpContext.GetOwinContext().Authentication.Challenge(
                    properties,
                    OktaDefaults.MvcAuthenticationType);
                return new HttpUnauthorizedResult();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public void SignOut()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.SignOut(
                    CookieAuthenticationDefaults.AuthenticationType,
                    OktaDefaults.MvcAuthenticationType);
            }
        }
    }
}