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

        // alle ritten ophalen
        public IEnumerable<Rit> AlleRitten ()
        {
            return _RitRepository.All();
        }

    }
}
