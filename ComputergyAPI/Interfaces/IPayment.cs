using ComputergyAPI.DTOs.Payment;

namespace ComputergyAPI.Interfaces
{
    public interface IPayment
    {
        public Task<bool> CreateUpdatePaymentCard(CreateUpdatePaymentCardDTO input);
        public Task<bool> RemovePaymentCard(int CardId);

        public Task<PaymentDTO> GetPaymentCard(int CardId);
        public Task<List<PaymentDTO>> GetAll(int UserId);




    }
}
