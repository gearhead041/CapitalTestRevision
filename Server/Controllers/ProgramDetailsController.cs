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

        ///<summary>
        ///Create a program in the database. Returns a ProgramDetailDto Class.
        ///</summary>
        ///<param name="programDetailsDto"></param>
        [HttpPost]
        public async Task<ActionResult<ProgramDetailsDto>> CreateProgramDetail([FromBody] CreateProgramDetailsDto programDetailsDto)
        {
            return await serviceManager.ProgramService.CreateProgramDetails(programDetailsDto);
        }

        [Http]
    }
}