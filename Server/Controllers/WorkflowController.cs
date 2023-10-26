using Contracts.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public WorkflowController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Get workflow for a program with id programId.
        /// </summary>
        /// <param name="programId"></param>
        /// <returns>A single WorkflowDto, or NotFound if the program is not found.</returns>
        [HttpGet("{programId:guid}")]
        public async Task<ActionResult<WorkflowDto>> GetProgramDetail([FromRoute] Guid programId)
        {
            var workflow = await serviceManager.ProgramService.GetWorkflow(programId);
            if(workflow == null)
            {
                return NotFound();
            }

            return Ok(workflow);
        }

        /// <summary>
        /// Update the workflow for a program detail with id, programId.
        /// </summary>
        /// <param name="programId"></param>
        /// <returns>A single workflowDto or BadRequest if the program is not found.</returns>
        [HttpPut("{programId:guid}")]
        public async Task<ActionResult<WorkflowDto>> UpdateWorkflow([FromRoute]Guid programId, [FromBody] WorkflowDto workflowDto)
        {
           var workflow = await serviceManager.ProgramService.UpdateWorkflow(programId,workflowDto);
            if (workflow == null)
            {
                return BadRequest("prgram does not exist");
            }
            return Ok(workflow);
        }

    }
}