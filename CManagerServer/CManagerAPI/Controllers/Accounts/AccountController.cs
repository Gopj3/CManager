using System.IdentityModel.Tokens.Jwt;
using CManagerApplication.Common.Helpers;
using CManagerApplication.Models.Requests.Account;
using CManagerApplication.Models.Results.Account;
using CManagerData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CManagerAPI.Controllers.Accounts
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtHelper _jwtHelper;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            JwtHelper jwtHelper
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest model)
        {
            if (model == null || !ModelState.IsValid)
            {
                var modelStateErrors = ModelState.Select(x => x.Value?.Errors?
                    .FirstOrDefault(el => el.ErrorMessage != null)).Select(el => el?.ErrorMessage)
                    .ToList();

                return BadRequest(new RegistrationResult { Errors = modelStateErrors });
            }

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new RegistrationResult { IsSuccessfulRegistration = true});
            }

            var errors = result.Errors.Select(e => e.Description);

            return BadRequest(new RegistrationResult { IsSuccessfulRegistration = false, Errors = errors}) ;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);


            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new AuthResult { ErrorMessage = "Invalid Authentication" });

            var signingCredentials = _jwtHelper.GetSigningCredentials();
            var claims = _jwtHelper.GetClaims(user);
            var tokenOptions = _jwtHelper.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResult { IsAuthSuccessful = true, Token = token });
        }
    }
}

