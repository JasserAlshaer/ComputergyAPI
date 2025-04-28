using Microsoft.AspNetCore.Mvc;
using ComputergyAPI.Helpers;
using ComputergyAPI.Models;


namespace ComputergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        [HttpPost("hash")]
        public IActionResult HashPassword([FromBody] PassInput input)
        {
            if (string.IsNullOrEmpty(input.Password))
                return BadRequest("Password is required.");

            var hashed = PasswordHasher.HashPassword(input.Password);
            return Ok(new { HashedPassword = hashed });
        }

        [HttpPost("verify")]
        public IActionResult VerifyPassword([FromBody] PassInput input)
        {
            if (string.IsNullOrEmpty(input.Password) || string.IsNullOrEmpty(input.HashedPassword))
                return BadRequest("Password and HashedPassword are required.");

            var isMatch = PasswordHasher.VerifyPassword(input.Password, input.HashedPassword);
            return Ok(new { IsMatch = isMatch });
        }
    }

    public class TestController
    {

        [HttpGet("error")]
        public IActionResult GenerateError()
        {
            throw new Exception("Test exception for logging!");
        }

    }

}
