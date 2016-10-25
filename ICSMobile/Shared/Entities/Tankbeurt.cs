using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Tankbeurt
    {
        public int TankbeurtID { get; set; }
        public double Liter { get; set; }
        public double StartKm { get; set; }
        public double EindKm { get; set; }

        // foreign key
        public string NummerPlaat { get; set; }
    }
}
