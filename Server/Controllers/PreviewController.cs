using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreviewController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public PreviewController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Get preview for a program with id programId.
        /// </summary>
        /// <param name="programId"></param>
        /// <returns>A single Dto, or NotFound if the program is not found.</returns>
        [HttpGet("{programId:guid}")]
        public async Task<ActionResult<PreviewDto>> GetProgramDetail([FromRoute] Guid programId)
        {
            var preview = await serviceManager.ProgramService.GetPreview(programId);
            if (preview == null)
            {
                return NotFound();
            }

            return Ok(preview);
        }
    }
}