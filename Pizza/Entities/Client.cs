using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Client
    {
        [Key]
        public int Num_Cli { get; set; }
        public string Nom_Cli { get; set; }
        public string Addresse { get; set; }
    }
}
