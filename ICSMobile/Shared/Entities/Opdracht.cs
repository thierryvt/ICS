using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Opdracht
    {
        public int OpdrachtID { get; set; }
        public string Naam { get; set; }
        public string Status { get; set; }
        public string Bijlage { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public bool Afgehandeld { get; set; }

        // Foreign keys
        public string ChauffeurID { get; set; }
        public string NummerPlaat { get; set; }

        // Navigation Properties 
        public ICollection<Rit> Ritten { get; set; }
        public Chauffeur _Chauffeur { get; set; }
        public Vrachtwagen _Vrachtwagen { get; set; }
    }
}
