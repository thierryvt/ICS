using DAL.Repositories.EF;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Collections.Generic;

namespace BL.Managers
{
    public class OpdrachtManager
    {
        private readonly IOpdrachtRepository _OpdrachtRepository = new OpdrachtRepository();

        //  aanmaken
        public void CreateOpdracht(Opdracht Opdracht)
        {
            _OpdrachtRepository.Create(Opdracht);
        }

        // alle Opdrachtten ophalen
        public IEnumerable<Opdracht> AlleOpdrachtten()
        {
            return _OpdrachtRepository.All();
        }

        // 1 specifieke Opdracht
        public Opdracht FindOpdracht(int id)
        {
            return _OpdrachtRepository.Find(id);
        }

        // Opdracht updaten
        public void UpdateOpdracht(Opdracht Opdracht)
        {
            _OpdrachtRepository.Update(Opdracht);
        }

        // Opdracht verwijderen
        public void Delete(int id)
        {
            _OpdrachtRepository.Delete(id);
        }
    }
}
