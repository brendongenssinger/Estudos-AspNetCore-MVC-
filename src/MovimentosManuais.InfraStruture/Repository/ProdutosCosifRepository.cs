using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.InfraStruture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.InfraStruture.Repository
{
    public class ProdutosCosifRepository : EFRepository<Produto_Cosif>
    {
        public ProdutosCosifRepository(MovimentosManuaisContext dbContext) : base(dbContext)
        {
        }
    }
}
