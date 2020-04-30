using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Adresses
    {
        [Key]
        public int Num_Adresse { get; set; }
        public string Adresse { get; set; }
        public int Num_Quartier { get; set; }
        [ForeignKey("Num_Quartier")]
        public Num_Cde_Cli Quartier { get; set; }
    }
}
