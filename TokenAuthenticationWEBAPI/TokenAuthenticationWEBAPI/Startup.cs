using System;
using Microsoft.Owin;
using Owin;
using TokenAuthenticationWEBAPI.Models;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using TokenAuthenticationWEBAPI;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(TokenAuthenticationInWebAPI.Startup))]
namespace TokenAuthenticationInWebAPI
{
    // In this class we will Configure the OAuth Authorization Server.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            SetCookieAuthenticationAsDefault(app);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                //The Path For generating the Token
                TokenEndpointPath = new PathString("/token"),
                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //My AuthorizationServerProvider class will validate the user credentials
                Provider = new AuthorizationServerProvider()
            };
            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        private void SetCookieAuthenticationAsDefault(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Login"),
                LogoutPath = new PathString("/Logout"),
                ExpireTimeSpan = TimeSpan.FromMinutes(5.0),
            });
        }

    }
}