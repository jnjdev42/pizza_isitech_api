using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Paiement_Cli
    {
        [Key]
        public int Num_Piece_Compt { get; set; }
        public int Num_Fact { get; set; }
        [ForeignKey("Num_Fact")]
        public Fact_Cli_BonLiv Fact_Cli_BonLiv { get; set; }
        public DateTime Date_Paiement { get; set; }
        public decimal Montant_Paiement { get; set; }
    }
}
