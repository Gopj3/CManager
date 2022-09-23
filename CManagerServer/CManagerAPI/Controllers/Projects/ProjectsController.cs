using CManagerAPI.Helpers.Users;
using CManagerApplication.Commands.Projects;
using CManagerApplication.Models.Requests.Projects;
using CManagerApplication.Queries.Projects;
using CManagerData.Enums.Projects;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CManagerAPI.Controllers.Projects;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync(CancellationToken cancellationToken)
    {
        var userId = HttpContext.GetUserId();
        var query = new GetProjectsQuery(userId);
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateProjectRequest request, CancellationToken token)
    {
        var userId = HttpContext.GetUserId();
        var command = new CreateProjectCommand
        {
            UserId = userId,
            Title = request.Title,
            Description = request.Description
        };

        await _mediator.Send(command, token);
        return Ok();
    }

    [HttpPost("{id}/users")]
    public async Task<IActionResult> AssignUserAsync(string id, [FromBody] AssignUserRequest request,
        CancellationToken token)
    {
        var userId = HttpContext.GetUserId();
        var successParse = Guid.TryParse(id, out var projectId);

        if (!successParse)
            return BadRequest("Invalid project id");

        var successParseRole = Enum.TryParse(request.ProjectRole, out ProjectUserRoleEnum role);

        if (!successParseRole)
            return BadRequest("Invalid role");

        var command = new AssignUserToProjectCommand
        {
            ProjectId = projectId,
            AssigneeId = request.UserId,
            AssignerId = userId,
            Role = role
        };

        await _mediator.Send(command, token);

        return Ok();
    }
}