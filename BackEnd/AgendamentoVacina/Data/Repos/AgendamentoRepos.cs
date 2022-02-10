using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repos
{
    public class AgendamentoRepos : IAgendamentoRepos
    {
        private readonly Context _context;

        public AgendamentoRepos(Context context)
        {
            _context = context;
        }

        public async Task<IList<Agendamento>> GetAll()
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            return await query.AsNoTracking().ToListAsync();   
        }

        public async Task<Agendamento> GetByCpf(string cpf)
        {
            IQueryable<Agendamento> query = _context.Agendamentos.Include("Endereco").Include("Posto").Where(x => x.Cpf.Equals(cpf));
            return await query.AsNoTracking().FirstOrDefaultAsync();                
        }

        public async Task<int> Insert(Agendamento obj)
        {            
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    IQueryable<Lote> query = _context.Lotes.Include("Posto").Where(x => x.IdPosto.Equals(obj.IdPosto) && (x.QuantidadeDoses - x.DosesReservadas - x.DosesAplicadas) > 0);
                    var lote = await query.AsNoTracking().FirstOrDefaultAsync();   
                    lote.DosesReservadas = lote.DosesReservadas + 1;

                    _context.Entry(lote).State = EntityState.Modified;

                    _context.Agendamentos.Add(obj);

                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return obj.Id;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
        }

        public async Task<bool> Update(Agendamento obj)
        {
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    IQueryable<Lote> query = _context.Lotes.Include("Posto").Where(x => x.IdPosto.Equals(obj.IdPosto)); 
                    var lote = await query.AsNoTracking().FirstOrDefaultAsync();                      
                    lote.DosesReservadas = lote.DosesReservadas - 1;
                    lote.DosesAplicadas = lote.DosesAplicadas + 1;

                    var end = await _context.Enderecos.FindAsync(obj.IdEndereco);
                    end.Cidade = obj.Endereco.Cidade;
                    end.Cep = obj.Endereco.Cep;
                    end.Bairro = obj.Endereco.Bairro;
                    end.Numero = obj.Endereco.Numero;
                    end.Rua = obj.Endereco.Rua;

                    _context.Entry(lote).State = EntityState.Modified;
                    _context.Entry(end).State = EntityState.Modified;
                    _context.Entry(obj).State = EntityState.Modified;

                    transaction.Commit();
                    return await _context.SaveChangesAsync() != 0;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}