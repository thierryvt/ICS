using Shared.Entities;
using System.Collections.Generic;

namespace DAL.Repositories.Contracts
{
    public interface IVrachtwagenRepository
    {
        Vrachtwagen Find(string id);
        IEnumerable<Vrachtwagen> All();
        void Create(Vrachtwagen v);
        void Update(Vrachtwagen v);
        void Delete(int id);
    }
}
