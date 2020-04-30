using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Profiles
{
    public class CataloguePizzaForUpdateDto
    {
        public string Nom_Pizza { get; set; }
        public int Taille_Pizza { get; set; }
        public decimal Prix_Pizza { get; set; }
    }
}
