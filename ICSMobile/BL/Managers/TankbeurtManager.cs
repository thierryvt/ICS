using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL.Managers
{
    public class TankbeurtManager
    {
        private readonly ITankBeurtRepository _TankbeurtRepository = new TankbeurtRepository();

        // tankbeurt aanmaken en gemiddelde berekenen

        //TODO: Huidige user toevoegen aan de tankbeurt
        public void CreateTankbeurt(Tankbeurt tankbeurt)
        {
            // Haal alle tankbeurten op en neem daarvan de km stand van de laatste tankbeurt.
            // LastOrDefault werkt niet in DAL (EF kan er niet mee overweg) waardoor de volledige lijst opgehaald moet worden.
            try
            {
                tankbeurt.StartKm = _TankbeurtRepository.AlleVoorVrachtwagen(tankbeurt.NummerPlaat).ToList().LastOrDefault().EindKm;
            }
            catch (NullReferenceException e)
            {
                tankbeurt.StartKm = 0;
            }
            catch (Exception e)
            {
                // een foutmelding weergeven op het scherm?
                Console.WriteLine("{0} Second exception caught.", e);
            }

            tankbeurt.Verbruik = (tankbeurt.Liter / (tankbeurt.EindKm - tankbeurt.StartKm))*100;
            _TankbeurtRepository.Create(tankbeurt);
        }

        // alle tankbeurtten ophalen
        public IEnumerable<Tankbeurt> AlleTankbeurten()
        {
            return _TankbeurtRepository.All();
        }

        // 1 specifieke tankbeurt
        public Tankbeurt FindTankbeurt(int id)
        {
            return _TankbeurtRepository.Find(id);
        }

        // tankbeurt updaten
        public void UpdateTankbeurt(Tankbeurt tankbeurt)
        {
            tankbeurt.Verbruik = (tankbeurt.Liter / (tankbeurt.EindKm - tankbeurt.StartKm)) * 100;
            _TankbeurtRepository.Update(tankbeurt);
        }

        // tankbeurt verwijderen
        public void Delete(int id)
        {
            _TankbeurtRepository.Delete(id);
        }
    }
}
