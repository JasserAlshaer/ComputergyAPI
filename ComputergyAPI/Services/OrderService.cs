using ComputergyAPI.DTOs.Order;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class OrderService : IOrder
    {
        public Task<string> CreateUpdateOrder(CreateUpdateOrderInputDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> GetAllOrder()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> SearchOrder(SearchOrderInputDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
