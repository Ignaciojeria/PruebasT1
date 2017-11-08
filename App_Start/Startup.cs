﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using webapi2Tarea.Provider;

[assembly: OwinStartup(typeof(webapi2Tarea.App_Start.Startup))]

namespace webapi2Tarea.App_Start
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
               
                //Ruta para solicitar el token. se mandan las credenciales por post.
                TokenEndpointPath = new PathString("/auth"),
                Provider = new OAuthAppProvider(),
                //Tiempo de expiración del token
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
            
        }
    }
}