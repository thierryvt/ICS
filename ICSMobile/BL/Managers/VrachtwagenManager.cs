using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using Shared.Entities;
using System.Collections.Generic;

namespace BL.Managers
{
    public class VrachtwagenManager
    {
        private readonly IVrachtwagenRepository _VrachtwagenRepository = new VrachtwagenRepository();

        // vrachtwagen aanmaken

        public void CreateVrachtwagen(Vrachtwagen vrachtwagen)
        {
            _VrachtwagenRepository.Create(vrachtwagen);
        }

        // alle vrachtwagenten ophalen
        public IEnumerable<Vrachtwagen> AlleVrachtwagenen()
        {
            return _VrachtwagenRepository.All();
        }

        // 1 specifieke vrachtwagen
        public Vrachtwagen FindVrachtwagen(string id)
        {
            return _VrachtwagenRepository.Find(id);
        }

        // vrachtwagen updaten
        public void UpdateVrachtwagen(Vrachtwagen vrachtwagen)
        {
            _VrachtwagenRepository.Update(vrachtwagen);
        }

        // vrachtwagen verwijderen
        public void Delete(int id)
        {
            _VrachtwagenRepository.Delete(id);
        }
    }
}
