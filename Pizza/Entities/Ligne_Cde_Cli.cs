using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Ligne_Cde_Cli
    {
        [Key]
        public int Num_Ligne_Cde { get; set; }
        public int Num_Cde_Cli { get; set; }
        [ForeignKey("Num_Cde_Cli")]
        public CdeCli CdeCli { get; set; }
        public int Num_Pizza { get; set; }
        [ForeignKey("Num_Pizza")]
        public Catalogue_Pizza Catalogue_Pizza { get; set; }
        public int Quantite { get; set; }
    }
}
