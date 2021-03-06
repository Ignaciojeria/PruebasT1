﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using webapi2Tarea.App_Start;
using webapi2Tarea.Entity;
using webapi2Tarea.Models;
using webapi2Tarea.ServiceImpl;

namespace webapi2Tarea.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public object StartUp { get; private set; }

   

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var postUser = context.UserName;
                var password = context.Password;
                var userService = new UsuarioService();

                Usuario user = userService.findUserByUserModel(new UserModel(){usuario=postUser,contrasena=password});
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.correo),
                        new Claim("UserID", user.Alias)
                    };

                    ClaimsIdentity oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties() { }));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

    }
}