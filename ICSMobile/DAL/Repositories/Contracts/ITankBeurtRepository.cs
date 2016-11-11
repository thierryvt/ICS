using Shared.Entities;
using System.Collections.Generic;
using System;


namespace DAL.Repositories.Contracts
{
    public interface ITankBeurtRepository
    {
        Tankbeurt Find(int id);
        IEnumerable<Tankbeurt> All();
        IEnumerable<Tankbeurt> All(DateTime time);
        IEnumerable<Tankbeurt> AlleVoorVrachtwagen(string nummerplaat);
        void Create(Tankbeurt t);
        void Update(Tankbeurt t);
        void Delete(int id);
    }
}
