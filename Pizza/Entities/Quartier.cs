using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Num_Cde_Cli
    {
        [Key]
        public int Num_Quartier { get; set; }
        public string Nom_Quartier { get; set; }
    }
}
