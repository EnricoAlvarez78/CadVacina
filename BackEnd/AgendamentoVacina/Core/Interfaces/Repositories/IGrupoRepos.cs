using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IGrupoRepos
    {
        Task<IList<Grupo>> GetAll();
        Task<Grupo> GetById(int id);
        Task<IList<Grupo>> GetListByAge(int age);
        Task<int> Insert(Grupo obj);
        Task<bool> Update(Grupo obj);
        Task<bool> Delete(int id);            
    }
}