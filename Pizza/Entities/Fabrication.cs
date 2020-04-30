using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Entities
{
    public class Fabrication
    {
        [Key]
        public int Num_Fab { get; set; }
        public int Num_Pizza { get; set; }
        [ForeignKey("Num_Pizza")]
        public Catalogue_Pizza Catalogue_Pizza { get; set; }
        public int Quant_Fab { get; set; }
        public DateTime Date_Fab { get; set; }
    }
}
