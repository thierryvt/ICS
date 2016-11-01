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

    }
}
