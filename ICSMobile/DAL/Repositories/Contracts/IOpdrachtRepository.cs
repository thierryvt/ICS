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
        Opdracht AlleOpdrachtRitten(int id);
        void Create(Opdracht o);
        void Update(Opdracht o);
        void Delete(int id);
    }
}
