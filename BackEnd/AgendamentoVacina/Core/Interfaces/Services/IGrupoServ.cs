using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IGrupoServ
    {
        Task<IList<Grupo>> GetAll();
        Task<Grupo> GetById(int id);
        Task<IList<Grupo>> GetListByAge(DateTime date);
        Task<int> Insert(Grupo Grupo);
        Task<bool> Update(Grupo Grupo);
        Task<bool> Delete(int id);
    }
}