using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class LigneCommandeForCreateDto
    {
        public int Num_Cde_Cli { get; set; }
        public int Num_Pizza { get; set; }
        public int Quantite { get; set; }
    }
}
