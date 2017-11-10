using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi2Tarea.Extensions
{
    public static class OwinContextExtensions
    {
        //El post va Asì -> grant_type=password&username=admin@domain.com&password=admin
        public static string GetUserId(this IOwinContext ctx)
        {
            var result = "-1";
            var claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (claim != null)
            {
                result = claim.Value;
            }
            return result;
        }
    }
}