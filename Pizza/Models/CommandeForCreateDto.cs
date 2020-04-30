using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class CommandeForCreateDto
    {
        public int Num_Cli { get; set; }
        public bool Livre_Emporte { get; set; }
    }
}
