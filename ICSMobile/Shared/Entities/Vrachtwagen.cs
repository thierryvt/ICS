using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Vrachtwagen
    {
        [Key]
        public string NummerPlaat { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public double TotaalKM { get; set; }
        public DateTime DatumInDienst { get; set; }

    }
}
