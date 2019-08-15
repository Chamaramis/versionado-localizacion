
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamGranillo.VersionadoLocalizacion.Web.Controllers
{
    [Route("[controller]/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1")]
    public class TestingController : ControllerBase
    {
        public TestingController()
        {
            
        }

        [HttpGet]
        public IActionResult Hello() => this.Ok("holi versión 1");
    }
}