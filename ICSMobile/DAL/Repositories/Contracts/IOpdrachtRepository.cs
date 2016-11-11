using Shared.Entities;
using System.Collections.Generic;
using System;


namespace DAL.Repositories.Contracts
{
    public interface IOpdrachtRepository
    {
        Opdracht Find(int id);
        Opdracht FindMetVrachtwagen(int id);
        IEnumerable<Opdracht> All();
        IEnumerable<Opdracht> All(DateTime time);
        IEnumerable<Opdracht> AlleOpdrachtenMetChauffeur();
        IEnumerable<Opdracht> AlleLopendeMetChauffeur();
        IEnumerable<Opdracht> AlleAfgelopen();
        Opdracht OpdrachtAlleRitten(int id);
        void Create(Opdracht o);
        void Update(Opdracht o);
        void Delete(int id);
    }
}
