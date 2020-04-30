using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class BonLiv
    {
        [Key]
        public int Num_Bon_Liv { get; set; }
        public int Num_Cde_Cli { get; set; }
        [ForeignKey("Num_Cde_Cli")]
        public CdeCli CdeCli { get; set; }
        public DateTime Date_Liv { get; set; }
        public int Num_Fact { get; set; }
        [ForeignKey("Num_Fact")]
        public Fact_Cli_BonLiv Fact_Cli_BonLiv { get; set; }
    }
}
