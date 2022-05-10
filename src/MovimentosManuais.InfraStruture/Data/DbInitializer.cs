using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovimentosManuais.InfraStruture.Data
{
    public class DbInitializer
    {
        private MovimentosManuaisContext _context;


        public DbInitializer(MovimentosManuaisContext context)
        {
            _context = context;
           
        }

        public void Initilialize() 
        {
            
            if (!_context.Produto_Cosifs.Any())
            {
                _context.Produto_Cosifs.AddRange(ObterListaProdutoCosif());
                _context.SaveChanges();
            }

            
        }

       
        

        private Produto_Cosif[] ObterListaProdutoCosif()
        {
            return new Produto_Cosif[]
            {
                new Produto_Cosif
                {
                    COD_COSIF = "001",
                    COD_PRODUTO = "PROD 001",
                    COD_CLASSIFICACAO = "CLA1",
                    STA_STATUS = "0",
                    Produto = new Produto()
                    {
                        COD_PRODUTO = "PROD 001",
                        DES_PRODUTO = "DESC 001",
                        STA_STATUS = "0",
                    }
                
                },
                new Produto_Cosif
                {
                    COD_COSIF = "002",
                    COD_PRODUTO = "PROD 002",
                    COD_CLASSIFICACAO = "CLA2",
                    STA_STATUS = "0",
                    Produto = new Produto()
                    {
                        COD_PRODUTO = "PROD 002",
                        DES_PRODUTO = "DESC 002",
                        STA_STATUS = "1",
                    }
                },
            };   
        }
    }
}
