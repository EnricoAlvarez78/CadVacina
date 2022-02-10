using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class GrupoServ : IGrupoServ
    {
        private readonly IGrupoRepos _grupoRepos;

        public GrupoServ(IGrupoRepos grupoRepos) => _grupoRepos = grupoRepos;

        public async Task<IList<Grupo>> GetAll()
        {
            return await _grupoRepos.GetAll();
        }

        public async Task<Grupo> GetById(int id)
        {
            return await _grupoRepos.GetById(id);
        }

        public async Task<int> Insert(Grupo obj)
        {
            return await _grupoRepos.Insert(obj);
        }

        public async Task<bool> Update(Grupo obj)
        {
            return await _grupoRepos.Update(obj);
        }

        public async Task<bool> Delete(int id)
        {
            return await _grupoRepos.Delete(id);
        }

        public async Task<IList<Grupo>> GetListByAge(DateTime date)
        {
            return await _grupoRepos.GetListByAge(CalcAge(date));
        }

        private int CalcAge(DateTime date)
        {
            int age = DateTime.Now.Year - date.Year;
            if(DateTime.Now.DayOfYear < date.DayOfYear)
                age = age -1;
            return age;
        }
    }
}