using LancamentoContabil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Repository
{
    public interface ILancamentoRepository : IRepositoryBase<Lancamento>
    {
        Lancamento RecuperarLancamento(int Id);
        Lancamento RecuperarLacamentoComContacontabil(int Id);

        void ExcluirLancamento(int Id);
    }
}
