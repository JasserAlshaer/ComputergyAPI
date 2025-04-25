using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class DiscountService : IDiscount
    {
        public Task<string> CreateDiscount(DiscountInputDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDiscount(int discountId)
        {
            throw new NotImplementedException();
        }

        public Task<Interfaces.IDiscount> GetAllDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateDiscount(int discountId, DiscountInputDTO input)
        {
            throw new NotImplementedException();
        }

        Task<DiscountDTO> IDiscount.GetAllDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
