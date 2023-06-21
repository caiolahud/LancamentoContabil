using LancamentoContabil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Interface
{
    public interface ILancamentoRepository : IRepositoryBase<Lancamento>
    {
        IQueryable<Lancamento> RecuperarLancamento(Lancamento lancamento);
        IQueryable<Lancamento> RecuperarLacamentoEhContacontabil(Lancamento lancamento);
    }
}
