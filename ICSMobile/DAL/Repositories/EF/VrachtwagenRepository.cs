using System.Collections.Generic;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Linq;

namespace DAL.Repositories.EF
{
    public class VrachtwagenRepository : IVrachtwagenRepository
    {

        private readonly IcsContext _ctx = new IcsContext();

        public IEnumerable<Vrachtwagen> All()
        {
            return _ctx.Vrachtwagens.AsEnumerable();
        }

        public void Create(Vrachtwagen v)
        {
            _ctx.Vrachtwagens.Add(v);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Vrachtwagens.Remove(_ctx.Vrachtwagens.Find(id));
            _ctx.SaveChanges();
        }

        public Vrachtwagen Find(string id)
        {
            return _ctx.Vrachtwagens.Find(id);
        }

        public void Update(Vrachtwagen v)
        {
            _ctx.Entry(_ctx.Vrachtwagens.Find(v.NummerPlaat)).CurrentValues.SetValues(v);
            _ctx.SaveChanges();
        }
    }
}
