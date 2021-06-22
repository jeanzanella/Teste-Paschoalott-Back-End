using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste_Paschoalott_Back_End.Models
{
    public class Titulo
    {
        public long Id { get; set; }
        [Required]
        public long NumeroTitulo { get; set; }
        [Required]
        public string NomeDevedor { get; set; }
        [Required]
        public string CpfDevedor { get; set; }
        public double PercentualJuros { get; set; }
        public double PercentualMulta { get; set; }

        public virtual ICollection<Parcela> Parcelas { get; set; }
    }
}
