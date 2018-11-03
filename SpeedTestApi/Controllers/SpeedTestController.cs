using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpeedTestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeedTestController : ControllerBase
    {
        // GET speedtest/ping
        [Route("ping")]
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return Ok("PONG");
        }
    }
}
