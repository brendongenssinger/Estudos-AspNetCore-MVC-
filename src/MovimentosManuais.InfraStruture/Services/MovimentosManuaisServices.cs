using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;

using MovimentosManuais.InfraStruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovimentosManuais.InfraStruture.Services
{
    public class MovimentosManuaisServices : IMovimentosManuaisServices
    {
        private MovimentoManualRepository _repository;
        public MovimentosManuaisServices(MovimentoManualRepository movimentoRepository)
        {
            _repository = movimentoRepository;
        }

        public Movimento_Manual Adicionar(Movimento_Manual entity)
        {

            var valorMax = _repository.Buscar(x => x.DAT_MES == entity.DAT_MES && x.DAT_ANO == entity.DAT_ANO).ToList();
            decimal numLanc = 1m;

            if(valorMax.Any())
                numLanc = valorMax.Max(x => x.NUM_LANCAMENTO) + 1;

            entity.NUM_LANCAMENTO = numLanc;
            _repository.Adicionar(entity);
            return entity;
        }

        public void Atualizar(Movimento_Manual entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movimento_Manual> Buscar(Expression<Func<Movimento_Manual, bool>> predicado)
        {
            throw new NotImplementedException();
        }

      

        public Movimento_Manual ObterId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Produto_Cosif> ObterListaProdutosCosif()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movimento_Manual> ObterTodos()
        {
<<<<<<< HEAD
            var result = _repository.ObterTodos().ToList();
=======
            var result = _repository.ObterTodos().ToList().Take(5);
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad
            return result;
        }

        public void Remover(Movimento_Manual entity)
        {
            throw new NotImplementedException();
        }
    }
}
