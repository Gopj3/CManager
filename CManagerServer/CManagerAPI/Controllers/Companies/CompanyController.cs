using System.Security.Claims;
using CManagerApplication.Commands.Companies;
using CManagerApplication.Models.Requests.Companies;
using CManagerData.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CManagerAPI.Controllers.Companies
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;

        public CompanyController(IMediator mediator, UserManager<User> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyRequest model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return BadRequest();
                }

                var command = new CreateCompanyCommand
                {
                    CreatorId = new Guid(userId),
                    Title = model.Title,
                    Description = model.Description,
                };

                try
                {
                    var result = await _mediator.Send(command);

                    return Ok(result);
                }catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest();
        }
    }
}

