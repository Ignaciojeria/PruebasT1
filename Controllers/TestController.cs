using System;
using System.Collections.Generic;
using System.Web.Http;
using webapi2Tarea.Entity;
using webapi2Tarea.IService;
using webapi2Tarea.Repository;

namespace webapi2Tarea.Controllers
{
    public class TestController : ApiController
    {
        private SGR4Context db = new SGR4Context();

        private IAcreditaNacionalidadService _service;
        public TestController(IAcreditaNacionalidadService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {   
            return Ok(_service.findAll());
        }
    }
}
