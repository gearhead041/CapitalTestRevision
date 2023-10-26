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
        ///Create a program.
        ///</summary>
        ///<param name="programDetailsDto">The DTO of the program to create</param>
        ///<returns>The created ProgramDetailDto</returns>
        [HttpPost]
        public async Task<ActionResult<ProgramDto>> CreateProgramDetail([FromBody] CreateProgramDto programDetailsDto)
        {
            return await serviceManager.ProgramService.CreateProgram(programDetailsDto);
        }

        /// <summary>
        /// Get a single program detail with id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single program detail, or NotFound if the program is not found.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProgramDto>> GetProgramDetail([FromRoute] Guid id)
        {
            var programDetail = await serviceManager.ProgramService.GetProgram(id);
            if(programDetail == null)
            {
                return NotFound();
            }

            return Ok(programDetail);
        }

        /// <summary>
        /// Update a program detail with id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A single program detail or BadRequest if the program is not found.</returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProgramDto>> UpdateProgramDetail([FromRoute]Guid id)
        {
           var programDetail = await serviceManager.ProgramService.UpdateProgram(id);
            if (programDetail == null)
            {
                return BadRequest("prgram does not exist");
            }
            return Ok(programDetail);
        }
    }
}