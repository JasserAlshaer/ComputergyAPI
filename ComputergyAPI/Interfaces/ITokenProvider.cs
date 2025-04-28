using ComputergyAPI.Entites;

namespace ComputergyAPI.Interfaces
{
    public interface ITokenProvider
    {
        string CreateToken(Person user);
    }
}
