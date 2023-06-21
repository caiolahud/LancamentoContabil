using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LancamentoContabil.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        IQueryable<T> RecuperarTodos();
        T RecuperarPeloID(int Id);
        T First(Expression<Func<T, bool>> expression); //Retorna o primeiro dado que atende o critério informado via expressão lambda.
        T Find(params object[] key); //Recebe um array de objetos e efetua a pesquisa pela chave primária;


    }
}
