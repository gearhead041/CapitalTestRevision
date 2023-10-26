using Contracts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ApplicationController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Get application template for the program with id programId.
        /// </summary>
        /// <param name="programId"></param>
        /// <returns>A single ApplicationDto or NotFound() if the program is not found.</returns>
        [HttpGet("{programId:guid}")]
        public async Task<ActionResult<ApplicationDto>> GetApplication(Guid programId)
        {
            var application = await serviceManager.ProgramService.GetApplication(programId);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        [HttpPut("{programId:guid}")]
        public async Task<ActionResult<ApplicationDto>> UpdateApplication(Guid programId, ApplicationDto applicationDto)
        {
            var application = await serviceManager.ProgramService.UpdateApplication(programId,applicationDto);
            if (application == null)
            {
                return BadRequest();
            }
            return Ok(application);
        }
    }
}
