using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Paschoalott_Back_End.Models
{
    public class Parcela
    {
        public long Id { get; set; }
        [Required]
        public long NumeroParcela { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        [Required]
        public double Valor { get; set; }
    }
}
