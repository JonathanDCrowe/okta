using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;

namespace WebFormsOktaExample
{
    /// <summary>
    /// Summary description for Signin
    /// </summary>
    public class Signin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated == false)
            {
                var properties = new AuthenticationProperties
                {
                    RedirectUri = "/Account.aspx"
                };

                context.GetOwinContext().Authentication.Challenge(
                    properties,
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}