using LancamentoContabil.Data;
using LancamentoContabil.Interface;
using LancamentoContabil.Model;
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

        public IQueryable<Lancamento> RecuperarLacamentoEhContacontabil(Lancamento lancamento)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lancamento> RecuperarLancamento(Lancamento lancamento)
        {
            throw new NotImplementedException();
        }
    }
}
