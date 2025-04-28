using ComputergyAPI.Entites;
using ComputergyAPI.Services;

namespace ComputergyAPI.Interfaces
{
    public interface Discountservervice
    {
        //define sigature for the targeted method 
        Task<string> GetDiscounts();
        Task<string> GetDiscountById(int id);
        Task<string> UpdateDiscount(int id, Discount input);
        Task<string> DeleteDiscount(int id);
    }
    
}
