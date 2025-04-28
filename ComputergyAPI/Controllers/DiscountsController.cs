using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscount _discountService;

        public DiscountsController(IDiscount discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("Create-Discount")]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountInputDTO input)
        {
            var result = await _discountService.CreateDiscount(input);
            return Ok(result);
        }

        [HttpGet("Get-allDiscounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = await _discountService.GetAllDiscount();
            return Ok(discounts);
        }

        [HttpPut("Update Discount/{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] DiscountInputDTO input)
        {
            var result = await _discountService.UpdateDiscount(id, input);
            return Ok(result);
        }

        [HttpDelete("Detete-Discount/{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var result = await _discountService.DeleteDiscount(id);
            if (!result)
                return NotFound("Discount not found");

            return Ok("Discount deleted successfully");
        }
    }
}
