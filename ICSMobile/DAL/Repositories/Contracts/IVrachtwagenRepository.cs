using Shared.Entities;
using System.Collections.Generic;

namespace DAL.Repositories.Contracts
{
    public interface IVrachtwagenRepository
    {
        Vrachtwagen Find(int id);
        IEnumerable<Vrachtwagen> All();
        void Create(Vrachtwagen v);
        void Update(int id, Vrachtwagen v);
        void Delete(int id);
    }
}
