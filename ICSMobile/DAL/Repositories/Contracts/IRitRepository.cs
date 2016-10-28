using Shared.Entities;
using System.Collections.Generic;
using System;


namespace DAL.Repositories.Contracts
{
    public interface IRitRepository
    {
        Rit Find(int id);
        IEnumerable<Rit> All();
        IEnumerable<Rit> All(DateTime time);
        void Create(Rit r);
        void Update(int id, Rit r);
        void Delete(int id);
    }
}
