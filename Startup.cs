using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

//[assembly: OwinStartupAttribute(typeof(webapi2Tarea.App_Start.Startup))]

namespace webapi2Tarea.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

          //  appBuilder.UseWebApi(config);
            ConfigureAuth(app);



     
        }
    }
}