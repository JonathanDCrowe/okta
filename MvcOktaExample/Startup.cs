﻿using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using Owin;
using System;
using System.Configuration;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOktaMvc(new OktaMvcOptions()
            {
                OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"],
                ClientId = ConfigurationManager.AppSettings["okta:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["okta:ClientSecret"],
                RedirectUri = ConfigurationManager.AppSettings["okta:RedirectUri"],
                PostLogoutRedirectUri = ConfigurationManager.AppSettings["okta:PostLogoutRedirectUri"],
                LoginMode = LoginMode.SelfHosted,
            });
        }
    }
}
