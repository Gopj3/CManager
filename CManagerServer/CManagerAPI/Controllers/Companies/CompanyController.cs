using CManagerAPI.Helpers.Users;
using CManagerApplication.Commands.Companies;
using CManagerApplication.Models.Requests.Companies;
using CManagerApplication.Queries.Companies;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CManagerAPI.Controllers.Companies
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController: ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyRequest model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.GetUserId();
                var command = new CreateCompanyCommand
                {
                    CreatorId = userId,
                    Title = model.Title,
                    Description = model.Description,
                };

                var result = await _mediator.Send(command);

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSingleAsync(string id)
        {
            var userId = HttpContext.GetUserId();
            var succeedParse = Guid.TryParse(id, out Guid companyId);

            if (succeedParse == false)
            {
                return BadRequest("Invalid id");
            }

            var query = new GetSingleCompanyQuery { Id = companyId, UserId = userId};
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("{id}/logo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadLogoAsync(string id)
        {
            var userId = HttpContext.GetUserId();
            var succeedParse = Guid.TryParse(id, out Guid companyId);

            if (!succeedParse)
            {
                return BadRequest("Invalid id");
            }

            IFormFile? file = Request.Form?.Files?[0];

            if (file == null)
            {
                return BadRequest("No file to upload");
            }

            var command = new UploadCompanyLogoCommand {
                UserId = userId,
                CompanyId = companyId,
                Logo = file
            };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}/logo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetLogoAsync(string id)
        {
            var succeedParse = Guid.TryParse(id, out Guid companyId);
            
            if (!succeedParse)
            {
                return BadRequest("Invalid id");
            }

            var query = new GetCompanyLogoQuery { CompanyId = companyId };
            var result = await _mediator.Send(query);

            return File(result.DataFiles, result.FileType);
        }
    }
}

