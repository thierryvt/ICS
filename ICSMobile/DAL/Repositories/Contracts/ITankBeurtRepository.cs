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
        void Create(Tankbeurt t);
        void Update(int id, Tankbeurt t);
        void Delete(int id);
    }
}
