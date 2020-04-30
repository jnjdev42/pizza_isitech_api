using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Livreur
    {
        [Key]
        public int Num_Liv { get; set; }
        public string Nom_Livreur { get; set; }
        public int Num_Quartier { get; set; }
        [ForeignKey("Num_Quartier")]
        public Num_Cde_Cli Quartier { get; set; }
    }
}
