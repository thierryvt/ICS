using System.Collections.Generic;
using Shared.Entities;
using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using System.Linq;
using System;

namespace BL.Managers
{
    public class RitManager
    {
        private readonly IRitRepository _RitRepository = new RitRepository();
        private readonly IOpdrachtRepository _OpdrachtRepository = new OpdrachtRepository();
        private readonly IVrachtwagenRepository _VrachtwagenRepository = new VrachtwagenRepository();

        // rit aanmaken
        public void CreateRit(Rit rit)
        {
            Opdracht o = _OpdrachtRepository.FindMetVrachtwagen(rit.OpdrachtID);
            // Zoek de laatste rit voor de gekozen vrachtwatgen en gebruik daar de eindstand van als nieuwe beginstand
            try
            {
                rit.BeginKm = _RitRepository.FindLast(rit.NummerPlaat).ToList().LastOrDefault().EindKm;
            }
            catch (NullReferenceException e)
            {
                rit.BeginKm = 0;
            }
            catch (Exception e)
            {
                // een foutmelding weergeven op het scherm?
                Console.WriteLine("{0} Second exception caught.", e);
            }


            // controleer het totaal km van de vrachtwagen. Indien kleiner dan eindkm van rit, verhoog het totaal km van de vrachtwagen
            if (rit.EindKm > o._Vrachtwagen.TotaalKM)
            {
                Vrachtwagen v = _VrachtwagenRepository.Find(o._Vrachtwagen.NummerPlaat);
                v.TotaalKM = rit.EindKm;
                _VrachtwagenRepository.Update(v);
            }
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
