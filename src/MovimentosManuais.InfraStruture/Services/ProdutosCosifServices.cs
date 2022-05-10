using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using MovimentosManuais.InfraStruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovimentosManuais.InfraStruture.Services
{
    public class ProdutosCosifServices : IProdutosCosifsServices
    {
        private ProdutosCosifRepository _repository;
        public ProdutosCosifServices(ProdutosCosifRepository produtosRepository)
        {
            _repository = produtosRepository;
        }

        public Produto_Cosif Adicionar(Produto_Cosif entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto_Cosif entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto_Cosif> Buscar(Expression<Func<Produto_Cosif, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public Produto_Cosif ObterId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto_Cosif> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(Produto_Cosif entity)
        {
            throw new NotImplementedException();
        }
    }
}
