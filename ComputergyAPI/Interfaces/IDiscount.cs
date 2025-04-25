using ComputergyAPI.DTOs.Discount;

namespace ComputergyAPI.Interfaces
{

    public interface IDiscount
    {
        Task<string> CreateDiscount(DiscountInputDTO input);
        Task<bool> DeleteDiscount(int discountId);
        Task<DiscountDTO> GetAllDiscount();
        Task<string> UpdateDiscount(int discountId, DiscountInputDTO input);
       
    }
}