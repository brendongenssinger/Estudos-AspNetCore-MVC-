using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Interfaces.Services
{
    public interface IServices<T>
    {
        
        T Adicionar(T entity);
        void Atualizar(T entity);
        IEnumerable<T> ObterTodos();
        T ObterId(int Id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado);
        void Remover(T entity);
    }
}
