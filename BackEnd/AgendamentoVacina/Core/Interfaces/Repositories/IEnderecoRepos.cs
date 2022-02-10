using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEnderecoRepos
    {
        Task<IList<Endereco>> GetAll();
        Task<Endereco> GetById(int id);
        Task<int> Insert(Endereco obj);
        Task<bool> Update(Endereco obj);
        Task<bool> Delete(int id);           
    }
}