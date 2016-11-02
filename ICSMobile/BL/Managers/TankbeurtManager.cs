using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using Shared.Entities;
using System.Collections.Generic;


namespace BL.Managers
{
    public class TankbeurtManager
    {
        private readonly ITankBeurtRepository _TankbeurtRepository = new TankbeurtRepository();

        // tankbeurt aanmaken en gemiddelde berekenen

        public void CreateTankbeurt(Tankbeurt tankbeurt)
        {
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
            _TankbeurtRepository.Update(tankbeurt);
        }

        // tankbeurt verwijderen
        public void Delete(int id)
        {
            _TankbeurtRepository.Delete(id);
        }
    }
}
