using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;
using DAL.Repositories.Contracts;
using DAL.Repositories.EF;

namespace BL.Managers
{
    public class ChauffeurManager
    {
        private readonly IChauffeurRepository _ChauffeurRepository = new ChauffeurRepository();

        // alle chauffeurs ophalen
        public IEnumerable<Chauffeur> AlleChauffeurs()
        {
            return _ChauffeurRepository.GetAllChauffeurs();
        }

        // 1 chauffeur met al zijn opdrachten en bijhorende ritten
        public Chauffeur AlleChauffeursMetOpdrachtRitten(string id)
        {
            return _ChauffeurRepository.FindAlleOpdrachtenRitten(id);
        }

        // 1 specifieke chauffeur
        public Chauffeur FindChauffeur(string id)
        {
            return _ChauffeurRepository.Find(id);
        }
    }
}

