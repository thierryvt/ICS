using System;
using System.Collections.Generic;
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
        [DataType(DataType.Date)]
        public DateTime DatumInDienst { get; set; }

        // Navigation Properties 
        public ICollection<Tankbeurt> Tankbeurten { get; set; }
    }
}
