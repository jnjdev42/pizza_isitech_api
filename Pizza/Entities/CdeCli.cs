using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class CdeCli
    {
        [Key]
        public int Num_Cde_Cli { get; set; }
        public int Num_Cli { get; set; }
        [ForeignKey("Num_Cli")]
        public Client Client { get; set; }
        public bool Livre_Emporte { get; set; }
        public DateTime Date_Cde { get; set; } = DateTime.Now;
        public ICollection<Ligne_Cde_Cli> Ligne_Cde_Clis{get; set;}
    }
}
