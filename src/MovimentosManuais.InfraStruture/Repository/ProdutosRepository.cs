using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.InfraStruture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.InfraStruture.Repository
{
    public class ProdutosRepository : EFRepository<Produto>
    {
        public ProdutosRepository(MovimentosManuaisContext dbContext) : base(dbContext)
        {
        }
    }
}
