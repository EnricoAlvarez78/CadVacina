using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUsuarioServ
    {
        Task<IList<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmail(string email);
        Task<Usuario> Login(string email, string senha);     
        Task<int> Insert(Usuario obj);
        Task<bool> Update(Usuario obj);
        Task<bool> UpdatePassword(Usuario obj);
        Task<bool> ResetPassword(Usuario obj);        
        Task<bool> Delete(int id);      
    }
}