using LancamentoContabil.Data;
using LancamentoContabil.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Repository
{
    public class LancamentoRepository : RepositoryBase<Lancamento>, ILancamentoRepository
    {
        private readonly DataContext _context;
        public LancamentoRepository(DataContext context) : base(context) 
        {
            _context= context;
        }

        public void ExcluirLancamento(int Id)
        {
            /*Esse método será responsável por excluir o lancamento junto com a conta contábil. 
            A conta contábil está relacionada com o lancamento, portanto o delete cascade deve ser feito pelo lancamento incluindo a conta.
            Adicionado o método SingleOrDefault após a consulta para garantir que apenas um único objeto Lancamento seja retornado*/

            var lancamentoComContacontabil = _context.LancamentoContabil
                .Where(p => p.Id == Id)
                .Include(p => p.ContasContabeis)
                .SingleOrDefault();

            if (lancamentoComContacontabil != null)
            {
                _context.Remove(lancamentoComContacontabil);
                _context.SaveChanges();
            }


        }

        public Lancamento RecuperarLacamentoComContacontabil(int Id)
        {
            var lancamentoComContacontabil = _context.LancamentoContabil
                 .Where(p => p.Id == Id)
                 .Include(p => p.ContasContabeis)
                 .FirstOrDefault();

            return lancamentoComContacontabil;
        }

        public Lancamento RecuperarLancamento(int Id)
        {
            var lancamento = _context.LancamentoContabil
                .Where(p => p.Id == Id)
                .SingleOrDefault();
            
            return lancamento;
        }
    }
}
