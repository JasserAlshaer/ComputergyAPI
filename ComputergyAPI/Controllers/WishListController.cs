using ComputergyAPI.DTOs.Carts;
using ComputergyAPI.Helpers;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly ICart _WishListServices;

        public WishListController(ICart CartServices)
        {
            _WishListServices = CartServices;
        }
        [HttpPost("Create-WishList{personId}")]
        public async Task<IActionResult> CreateWishlist([FromRoute] int personId)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(personId)) 
                    return Ok(_WishListServices.CreateWishlist(personId));

                throw new Exception("Person Id Is Invalid, Id Must Be Greater Than Zero");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
        [HttpPost("Add-To-WishList{itemId}")]
        public async Task<IActionResult> AddToWishlist([FromBody] WishListDTO wishListDTO)
        {
            try
            {
                if (CartitemValidationHelper.IsValidId(wishListDTO.ClientId) && CartitemValidationHelper.IsValidId(wishListDTO.ItemsID))
                    return Ok(_WishListServices.AddToWishlist(wishListDTO));

                throw new Exception("Client Id Or Item Id Is Invalid, Id Must Be Greater Than Zero");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Remove-Item{itemId}")]
        public async Task<IActionResult> RemoveFromWishlist([FromRoute] int itemId)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(itemId))
                    return Ok(_WishListServices.RemoveFromWishlist(itemId));

                throw new Exception("Invalid Item Id, Id Must Be Greater Then Zero");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Delete-WishList{personId}")]
        public async Task<IActionResult> DeleteWishlist([FromRoute] int personId)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(personId))
                    return Ok(_WishListServices.DeleteWishlist(personId));

                throw new Exception("Person Id Is Invalid, Id Must Be Greater Than Zero");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
