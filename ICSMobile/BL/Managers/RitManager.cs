using System.Collections.Generic;
using Shared.Entities;
using DAL.Repositories.Contracts;
using DAL.Repositories.EF;

namespace BL.Managers
{
    public class RitManager
    {
        private readonly IRitRepository _RitRepository = new RitRepository();

        // rit aanmaken
        public void CreateRit(Rit rit)
        {
            _RitRepository.Create(rit);
        }

        // alle ritten ophalen
        public IEnumerable<Rit> AlleRitten ()
        {
            return _RitRepository.All();
        }

        // 1 specifieke rit
        public Rit FindRit(int id)
        {
            return _RitRepository.Find(id);
        }

        // rit met opdracht en chauffeur gegevens ophalen
        public Rit FindRitMetChauffeur(int id)
        {
            return _RitRepository.FindMetOpdrachtChauffeur(id);
        }
        // rit updaten
        public void UpdateRit(Rit rit)
        {
            _RitRepository.Update(rit);
        }

        // rit verwijderen
        public void Delete(int id)
        {
            _RitRepository.Delete(id);
        }

        // alle ritten voor 1 bepaalde opdracht


    }
}
