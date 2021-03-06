﻿using DAL.Repositories.EF;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Collections.Generic;

namespace BL.Managers
{
    public class OpdrachtManager
    {
        private readonly IOpdrachtRepository _OpdrachtRepository = new OpdrachtRepository();

        //  aanmaken
        public void CreateOpdracht(Opdracht opdracht)
        {
            _OpdrachtRepository.Create(opdracht);
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

        // ophalen van opdracht met bijhorende vrachtwagen en chauffeur
        public Opdracht FindVrachtWagenChauffeur(int id)
        {
            return _OpdrachtRepository.FindMetVrachtwagenChauffeur(id);
        }

        // Opdracht updaten
        public void UpdateOpdracht(Opdracht opdracht)
        {
            _OpdrachtRepository.Update(opdracht);
        }

        // Opdracht verwijderen
        public void Delete(int id)
        {
            _OpdrachtRepository.Delete(id);
        }

        // ophalen van opdracht met alle bijhorende ritten  en chauffeurs
        public Opdracht AlleOpdrachtRitten(int id)
        {
            return _OpdrachtRepository.OpdrachtAlleRitten(id);
        }

        

        // ophalen alle opdrachten incl chauffeur gegevens
        public IEnumerable<Opdracht> AlleOpdrachttenMetChauffeur()
        {
            return _OpdrachtRepository.AlleOpdrachtenMetChauffeur();
        }

        // ophalen alle lopende opdrachten incl chauffeur
        public IEnumerable<Opdracht> AlleLopendeMetChauffeur()
        {
            return _OpdrachtRepository.AlleLopendeMetChauffeur();
        }

        // ophalen alle afgehandelde opdrachten
        public IEnumerable<Opdracht> AlleAfgehandeldeOpdrachten()
        {
            return _OpdrachtRepository.AlleAfgelopen();
        }
    }
}
