using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Tankbeurt
    {
        public int TankbeurtID { get; set; }
        public double Liter { get; set; }
        [DisplayName("Start km")]
        public double StartKm { get; set; }
        [DisplayName("Eind km")]
        public double EindKm { get; set; }
        public double Verbruik { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Datum { get; set; }

        // foreign key
        public string NummerPlaat { get; set; }
        public string ChauffeurID { get; set; }
    }
}
