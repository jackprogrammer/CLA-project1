using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLA.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
