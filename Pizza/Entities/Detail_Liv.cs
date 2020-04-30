using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Detail_Liv
    {
        [Key]
        public int Num_Detail_Bon_Liv { get; set; }
        public int Num_Bon_Liv { get; set; }
        [ForeignKey("Num_Bon_Liv")]
        public BonLiv BonLiv { get; set; }
        public int Num_Liv { get; set; }
        [ForeignKey("Num_Liv")]
        public Livraison Livraison { get; set; }
        public int Num_Quartier { get; set; }
        public string Addresse_Liv { get; set; }
    }
}
