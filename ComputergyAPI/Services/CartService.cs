using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Carts;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace ComputergyAPI.Services
{
    public class CartService : ICart
    {
        public Task<string> AddToWishlist(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddUpdateCart(CartItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public Task<string> ClearCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateCart(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateWishlist()
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteWishlist()
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveFromCart(int CartitemId)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveFromWishlist(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
