using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Produto_Cosif
    {
        public Produto_Cosif()
        {

        }

        [Key]
        public string COD_COSIF { get; set; }
        public Produto Produto { get; set; }
        [ForeignKey("Produto")]
        public string COD_PRODUTO { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
        public ICollection<Movimento_Manual> Contatos { get; set; }
    }
}
