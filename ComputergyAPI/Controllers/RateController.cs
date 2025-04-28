using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Rating.Request;
using ComputergyAPI.DTOs.Rating.Response;
using ComputergyAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly RateService _rateService;
        public RateController(RateService rateService)
        {
            _rateService = rateService;
        }
        [HttpPost("CreateRate")]
        public async Task<IActionResult> CreateRate(CreateRateDTO input)
        {
            try
            {
                _rateService.CreateRate(input);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }


        [HttpGet("GetRate")]
        public async Task<IActionResult> GetRate(int id)
        {
            try
            {
                _rateService.GetRateByOrderID(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
