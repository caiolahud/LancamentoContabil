using LancamentoContabil.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LancamentoContabil.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Adicionar(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(params object[] key)
        {
            return _dbSet.Find(key);
        }

        public T First(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public T RecuperarPeloID(int Id)
        {
            return _dbSet.Find(Id);
        }

        public IQueryable <T> RecuperarTodos()
        {
            return _dbSet;
        }
    }
}
