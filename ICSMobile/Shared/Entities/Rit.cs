using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Rit
    {
        public int RitID { get; set; }
        public string NummerPlaat { get; set; }
        public double BeginKm { get; set; }
        public double EindKm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime BeginTijd { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EindTijd { get; set; }

        //Foreign keys

        public int OpdrachtID { get; set; }

        // navigational properties
        public Opdracht opdracht { get; set; }
    }
}
