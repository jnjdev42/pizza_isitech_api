using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Catalogue_Pizza
    {
        [Key]
        public int Num_Pizza { get; set; }
        public string Nom_Pizza { get; set; }
        public int Taille_Pizza { get; set; }
        public decimal Prix_Pizza { get; set; }
    }
}
