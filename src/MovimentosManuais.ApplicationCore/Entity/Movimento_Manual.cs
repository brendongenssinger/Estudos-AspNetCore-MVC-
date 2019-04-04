using System;
using System.Collections.Generic;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    public class Movimento_Manual
    {
        public Movimento_Manual()
        {

        }
        public int DAT_MES { get; set; }
        public int DAT_ANO { get; set; }
        public int NUM_LANCAMENTO { get; set; }
        public int COD_PRODUTO { get; set; }
        public int COD_COSIF { get; set; }
        public int DES_DESCRICAO { get; set; }
        public int DAT_MOVIMENTO { get; set; }
        public int COD_USUARIO { get; set; }
        public int VAL_VALOR { get; set; }
    }
}
