using Shared.Entities;
using System.Collections.Generic;


namespace DAL.Repositories.Contracts
{
    public interface IChauffeurRepository
    {
        Chauffeur Find(string id);
        Chauffeur FindAlleOpdrachtenRitten(string id);
        IEnumerable<Chauffeur> GetAllChauffeurs();
        void UpdateChauffeur(string id, Chauffeur c);
    }
}
