using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Repository;
using MovimentosManuais.InfraStruture.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovimentosManuais.InfraStruture.Repository
{
    public class MovimentoManualRepository : EFRepository<Movimento_Manual>
    {
        public MovimentoManualRepository(MovimentosManuaisContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Movimento_Manual> ObterTodos()
        {
            var result = _dbContext.Set<Movimento_Manual>()
                .OrderByDescending(x => x.DAT_ANO).ThenBy(x => x.DAT_MES)
                .ThenBy(x => x.NUM_LANCAMENTO).ToList();
            var produtosCosif = _dbContext.Produto_Cosifs;
            result.ForEach(item => 
            {
                var _query = produtosCosif.Where(x => x.COD_COSIF == item.COD_COSIF);
                item.Produto_Cosif = _query.FirstOrDefault();
            });
            return result;
        }

        public override Movimento_Manual Adicionar(Movimento_Manual entity)
        {
            _dbContext.Set<Movimento_Manual>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
