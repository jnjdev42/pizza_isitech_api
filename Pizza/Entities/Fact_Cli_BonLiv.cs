using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Fact_Cli_BonLiv
    {
        [Key]
        public int Num_Fact { get; set; }
        public DateTime Date_Fact_Cli { get; set; }
        public decimal Montant_Total { get; set; }
        public int Num_Cli { get; set; }
        [ForeignKey("Num_Cli")]
        public Client Client { get; set; }
    }
}
