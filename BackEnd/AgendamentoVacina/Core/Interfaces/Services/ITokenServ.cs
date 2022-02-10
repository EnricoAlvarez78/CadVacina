using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface ITokenServ
    {
        string GenerateToken(Usuario user);
    }
}