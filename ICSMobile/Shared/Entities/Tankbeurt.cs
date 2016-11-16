using System.ComponentModel.DataAnnotations;

namespace Shared.Entities
{
    public class Tankbeurt
    {
        public int TankbeurtID { get; set; }
        public double Liter { get; set; }
        public double StartKm { get; set; }
        public double EindKm { get; set; }
        public double Verbruik { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Datum { get; set; }

        // foreign key
        public string NummerPlaat { get; set; }
        public string ChauffeurID { get; set; }
    }
}
