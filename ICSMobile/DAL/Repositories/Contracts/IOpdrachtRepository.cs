using Shared.Entities;
using System.Collections.Generic;
using System;


namespace DAL.Repositories.Contracts
{
    public interface IOpdrachtRepository
    {
        Opdracht Find(int id);
        IEnumerable<Opdracht> All();
        IEnumerable<Opdracht> All(DateTime time);
        void Create(Opdracht o);
        void Update(int id, Opdracht o);
        void Delete(int id);
    }
}
