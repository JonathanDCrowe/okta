using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/"
            };

            context.GetOwinContext().Authentication.Challenge(
                properties,
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
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