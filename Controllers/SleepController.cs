using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Tracing;

namespace webapi2Tarea.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SleepController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            Console.WriteLine("Has recibido una solicitud de un x cliente");
            Thread.Sleep(10000);
            return "Me he demorado 10 segundos en procesar la solicitud! Delegar a un procedimiento Sincrono";
        }

        [HttpGet]
        [Route("api/resource")]
        public string Resource()
        {

            return "Solicitud de carga inmediata! Delegar a procedimientos asincronos ;)";
        }
    }
}
