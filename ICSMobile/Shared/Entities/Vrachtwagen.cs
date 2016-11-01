using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Vrachtwagen
    {
        [Key]
        public string NummerPlaat { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public double TotaalKM { get; set; }
        public DateTime DatumInDienst { get; set; }

    }
}
