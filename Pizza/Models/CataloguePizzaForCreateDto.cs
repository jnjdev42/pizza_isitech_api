using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class CataloguePizzaForCreateDto
    {
        public string Nom_Pizza { get; set; }
        public int Taille_Pizza { get; set; }
        public decimal Prix_Pizza { get; set; }
    }
}
