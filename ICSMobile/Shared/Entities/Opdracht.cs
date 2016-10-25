using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Opdracht
    {
        public int OpdrachtID { get; set; }
        public string Status { get; set; }
        public string Bijlage { get; set; }

        // Foreign keys
        public string ChauffeurID { get; set; }

        // Navigation Properties 
    }
}
