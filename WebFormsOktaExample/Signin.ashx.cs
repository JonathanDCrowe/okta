using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Net.Http;
using System.Web;
using System.Linq;

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
                    RedirectUri = "/"
                };

                if (context.Request.HttpMethod == HttpMethod.Post.Method
                    && context.Request.Form["sessionToken"] != null)
                {
                    properties.Dictionary.Add("sessionToken", context.Request.Form["sessionToken"]);
                }

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