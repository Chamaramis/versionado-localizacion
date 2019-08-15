using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChamGranillo.VersionadoLocalizacion.Web.Controllers
{
    [Route("testing/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1.1")]
    public class TestingV1_1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello() => this.Ok("holi versión 1.1");
    }
}