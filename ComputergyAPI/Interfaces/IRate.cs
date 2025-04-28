using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.DTOs.Rating.Request;
using ComputergyAPI.DTOs.Rating.Response;
using ComputergyAPI.Entites;

namespace ComputergyAPI.Interfaces
{
    public interface IRate
    {
        Task<string> CreateRate(CreateRateDTO input);
        Task<List<GetRateDTO>> GetRateByOrderID(int id);
        
    }
}
