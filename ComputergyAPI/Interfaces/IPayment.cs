using ComputergyAPI.DTOs.Payment;
using ComputergyAPI.Entites;

namespace ComputergyAPI.Interfaces
{
    public interface IPayment
    {
        public Task<string> CreateUpdatePaymentCard(CreateUpdatePaymentCardDTO input);
        public Task<bool> RemovePaymentCard(int CardId);

        public Task<CardDTO> GetPaymentCard(int CardId);
        public Task<List<GetAllPaymentCardsDTO>> GetAll(int UserId);




    }
}
