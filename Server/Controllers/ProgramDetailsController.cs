using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramDetailsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProgramDetailsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
    }
}