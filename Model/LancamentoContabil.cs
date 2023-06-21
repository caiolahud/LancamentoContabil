using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Model
{
    public class Lancamento
    {
        public int Id { get; set; }
        public string CodEmpresa { get; set; }
        public string Lote { get; set; }
        public string Documento { get; set; }
        public DateTime DataLancamento { get; set; }

        public ICollection<ContasContabeis> ContasContabeis;
    }

    public class ContasContabeis
    {
        public int Id { get; set; }

        public string ContaContabil { get; set; }

        public string TipoLancamento { get; set; }

        public decimal Valor { get; set; }

        public string Historico { get; set; }
        public int LancamentoContabilId { get; set; }

        public Lancamento LancamentoContabil { get; set; }
    }
}
