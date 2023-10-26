
using Entities.Models;

namespace Entities.Dtos;

public class WorkflowDto
{
    public IEnumerable<Stage> Stages { get; set; } = Enumerable.Empty<Stage>();
}
