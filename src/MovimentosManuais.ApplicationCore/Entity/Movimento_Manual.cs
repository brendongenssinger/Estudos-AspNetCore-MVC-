using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Movimento_Manual
    {
        private string _codUsuario = "TESTE";

        public Movimento_Manual()
        {

        }
        
        [Required]
        [Range(1,12,ErrorMessage = "Número máximo é 12")]
        public int DAT_MES { get; set; }
        [Required]
        public int DAT_ANO { get; set; }
        [Required]
        public decimal NUM_LANCAMENTO { get; set; }
        [DataMember]
        
        public Produto Produto { get; set; }
        [ForeignKey("Produto")]
        [Required]
        public string COD_PRODUTO { get; set; }
        [DataMember]
        
        public Produto_Cosif Produto_Cosif { get; set; }

        [Required]
        [ForeignKey("Produto_Cosif")]
        public string COD_COSIF { get; set; }
        [Required]
        public string DES_DESCRICAO { get; set; }
        [Required]
        public DateTime DAT_MOVIMENTO { get; set; }
        public string COD_USUARIO { get=> _codUsuario ; set { _codUsuario = "TESTE"; } } 
        [Required]
        public decimal VAL_VALOR { get; set; }
    }
}
