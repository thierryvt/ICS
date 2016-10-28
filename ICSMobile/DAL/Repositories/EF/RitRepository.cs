using System.Collections.Generic;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Linq;
using System;

namespace DAL.Repositories.EF
{
    public class RitRepository : IRitRepository
    {
        private readonly IcsContext _ctx = new IcsContext();

        public IEnumerable<Rit> All()
        {
            return _ctx.Ritten.AsEnumerable();
        }

        public IEnumerable<Rit> All(DateTime time)
        {
            return _ctx.Ritten.Where(x => (x.Datum >= time)).AsEnumerable();
        }

        public void Create(Rit r)
        {
            _ctx.Ritten.Add(r);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Ritten.Remove(_ctx.Ritten.Find(id));
            _ctx.SaveChanges();
        }

        public Rit Find(int id)
        {
            return _ctx.Ritten.Find(id);
        }

        public void Update(int id, Rit r)
        {
            _ctx.Entry(_ctx.Ritten.Find(id)).CurrentValues.SetValues(r);
            _ctx.SaveChanges();
        }
    }
}
