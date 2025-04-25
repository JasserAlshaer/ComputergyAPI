using ComputergyAPI.DTOs.Payment;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class PaymentService : IPayment
    {
        public Task<bool> CreateUpdatePaymentCard(CreateUpdatePaymentCardDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<List<PaymentDTO>> GetAll(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentDTO> GetPaymentCard(int CardId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePaymentCard(int CardId)
        {
            throw new NotImplementedException();
        }
    }
}
