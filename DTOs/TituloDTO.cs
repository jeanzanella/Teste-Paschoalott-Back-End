using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Paschoalott_Back_End.DTOs
{
    public class TituloDTO
    {
        public long NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public long QtdeParcelas { get; set; }
        public double ValorOriginal { get; set; }
        public long DiasEmAtraso { get; set; }
        public double ValorAtualizado { get; set; }
    }
}
