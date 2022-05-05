using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enumerators;

namespace Core.Interfaces.Services
{
    public interface IEstatisticaServ
    {        
        Task<List<Estatistica>> GetEstatisticaByEstatisticaEnum(TipoEstatisticaEnum tipoEstatisticaEnum);
    }
}