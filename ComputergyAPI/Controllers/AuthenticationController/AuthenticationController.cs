using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers.AuthenticationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthanication _authenticationService;

        public AuthenticationController(IAuthanication authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
        {
            var token = await _authenticationService.SignUp(input);
            return Ok(token);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInInputDTO input)
        {
            var token = await _authenticationService.SignIn(input);

            if (string.IsNullOrEmpty(token) || token == "User not found")
                return Unauthorized(new { message = "Invalid credentials." });

            return Ok(new { token = token });
        }



    }
}
