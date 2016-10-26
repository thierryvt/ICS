using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Rit
    {
        public int RitID { get; set; }
        public string NummerPlaat { get; set; }
        public double BeginKm { get; set; }
        public double EindKm { get; set; }
        public DateTime Datum { get; set; }
        public DateTime BeginTijd { get; set; }
        public DateTime EindTijd { get; set; }

        //Foreign keys

        public int OpdrachtID { get; set; }
    }
}
