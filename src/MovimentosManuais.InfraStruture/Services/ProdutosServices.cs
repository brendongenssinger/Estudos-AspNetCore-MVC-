using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using MovimentosManuais.InfraStruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovimentosManuais.InfraStruture.Services
{
    public class ProdutosServices : IProdutoService
    {
        private ProdutosRepository _repository;
        public ProdutosServices(ProdutosRepository produtosRepository)
        {
            _repository = produtosRepository;
        }
        public Produto Adicionar(Produto entity)
        {
            _repository.Adicionar(entity);
            return entity;
        }

        public void Atualizar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Buscar(Expression<Func<Produto, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public Produto ObterId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return  _repository.ObterTodos();
        }

        public void Remover(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}
