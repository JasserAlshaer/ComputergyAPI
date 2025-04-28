using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Carts;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace ComputergyAPI.Services
{
    public class CartService : ICart
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public CartService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }
        public async Task<string> AddToWishlist(WishListDTO wishListDTO)
        {

            var wishlist = _computergyDbContext.Wishlists.Where(x => x.ClientId == wishListDTO.ClientId).SingleOrDefault();
            if (wishlist == null)
            {
                return "User Not Found!";
            }
            wishlist.ItemsID = wishListDTO.ItemsID;
            _computergyDbContext.Update(wishlist);
            _computergyDbContext.SaveChanges();

            return "Add Successfully";
        }

        public async Task<string> AddUpdateCart(CartItemDTO itemDTO)
        {
            var cartItem = _computergyDbContext.CartItems.Where(c => c.CartId == itemDTO.CartId).SingleOrDefault();
            if (cartItem == null)
            {
                return "Cart does not exist! Please create cart";
            }

            cartItem.ItemId = itemDTO.ItemId;   
            cartItem.Quantity = itemDTO.Quantity;
            cartItem.Note = itemDTO.Note;   
            cartItem.TotalPrice = itemDTO.TotalPrice;   // Not Implemented

            _computergyDbContext.Update(cartItem);
            _computergyDbContext.SaveChanges();
            return "Cart Updated Successfully";
        }

        public async Task<string> ClearCart(int cartId)
        {
            var cartItem = _computergyDbContext.CartItems.Where(c => c.CartId == cartId).SingleOrDefault();
            if (cartItem == null)
            {
                return "Cart is empty";
            }

            _computergyDbContext.Remove(cartItem);
            _computergyDbContext.SaveChanges();

            return "Cart Cleared Successfully";
        }
        public async Task<string> CreateCart(int personId)
        {
            var isCartExist = _computergyDbContext.Carts.Any(c => c.ClientId == personId);
            if(isCartExist)
               return "Cart already exists";
            

            Entites.Cart cart = new Entites.Cart();
            cart.ClientId = personId;
            _computergyDbContext.Update(cart);
            _computergyDbContext.SaveChanges();
            return "Cart Created Successfully";
        }

        public async Task<string> CreateWishlist(int personId)
        {
            var isWishlistExist = _computergyDbContext.Wishlists.Any(c => c.ClientId == personId);
            if (isWishlistExist)
            {
                return "Wishlist already exists";
            }

            Entites.Wishlist wishlist = new Entites.Wishlist();
            wishlist.ClientId = personId;

            _computergyDbContext.Update(wishlist);
            _computergyDbContext.SaveChanges();
            return "Wishlist Created Successfully";
        }

        public async Task<string> DeleteWishlist(int personId)
        {
            var isWishlistExist = _computergyDbContext.Wishlists.Any(x => x.ClientId == personId);
            if (!isWishlistExist) // if wishlist not exist
            {
                return "Wishlists does not exist";
            }

            var wishlist = _computergyDbContext.Wishlists.Where(x => x.ClientId == personId).SingleOrDefault();
            _computergyDbContext.Remove(wishlist);
            _computergyDbContext.SaveChanges();

            return "WishList Deleted Successfully";
        }

        public async Task<string> RemoveFromCart(int CartitemId)
        {
            
            var cartItem = _computergyDbContext.CartItems.Where(c => c.Id == CartitemId).SingleOrDefault();
            if (cartItem == null)
            {
                return "Cart Item does not exist";
            }

            
            _computergyDbContext.Remove(cartItem);
            _computergyDbContext.SaveChanges();

            return "Cart Item Removed Successfully";
        }

        public async Task<string> RemoveFromWishlist(int itemId)
        {
            var wishlist = _computergyDbContext.Wishlists.Where(c => c.ItemsID == itemId).SingleOrDefault();
            if (wishlist == null)
            {
                return "Item does not exist";
            }


            _computergyDbContext.Remove(wishlist);
            _computergyDbContext.SaveChanges();

            return "Wishlist Item Removed Successfully";
        }
    }
}
