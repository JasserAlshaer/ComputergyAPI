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
        Task<string> DeleteWishlist(int personId);
        Task<string> CreateWishlist(int personId);
        Task<string> AddToWishlist(WishListDTO wishListDTO);
        Task<string> RemoveFromWishlist(int itemId);
    }
}
