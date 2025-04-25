using ComputergyAPI.DTOs.Carts;
using ComputergyAPI.Entites;


namespace ComputergyAPI.Interfaces
{
    public interface  ICart
    {
        Task<string> ClearCart(int cartId);
        Task<string> CreateCart(int personId);
        Task<string> AddUpdateCart(CartItemDTO itemDTO);
        Task<string> RemoveFromCart(int CartitemId);
        Task<string> DeleteWishlist();
        Task<string> CreateWishlist();
        Task<string> AddToWishlist(int itemId);
        Task<string> RemoveFromWishlist(int itemId);
    }
}
