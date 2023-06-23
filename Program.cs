using LancamentoContabil.Data;
using LancamentoContabil.Model;
using LancamentoContabil.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil
{
    public class Program
    {
        private static ILancamentoRepository _lancamentoRepository;
        public static void Main()
        {
            InserirDados();
        }

        public static void InserirDados()
        {
            using var context = new DataContext();

            //var lancamento = new Lancamento
            //{
            //    CodEmpresa = "ABC",
            //    Lote = "123",
            //    Documento = "456",
            //    DataLancamento = DateTime.Now,
            //    ContasContabeis = new List<ContasContabeis>{
            //         new ContasContabeis
            //         {
            //             ContaContabil = "C123",
            //             TipoLancamento = "D",
            //             Valor = 100.00m,
            //             Historico = "Descrição da conta 1"
            //         },
            //        new ContasContabeis
            //        {
            //            ContaContabil = "C456",
            //            TipoLancamento = "C",
            //            Valor = 200.00m,
            //            Historico = "Descrição da conta 2"
            //        }
            //    }
            //};

            //context.LancamentoContabil.Add(lancamento);
            //context.SaveChanges();

            int id = 1; // Número de ID a ser consultado

            _lancamentoRepository.ExcluirLancamento(1);
                       


        }

    }
}
