using System.Collections.Generic;
using System.Web.Http;
using webapi2Tarea.IService;

namespace webapi2Tarea.Controllers
{
    public class TestController : ApiController
    {
        private IAcreditaCorreosService _service;
        public TestController(IAcreditaCorreosService service)
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
