using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Contracts;
using Shared.Entities;

namespace DAL.Repositories.EF
{
    public class TankbeurtRepository : ITankBeurtRepository
    {
        private readonly IcsContext _ctx = new IcsContext();
        public IEnumerable<Tankbeurt> All()
        {
            return _ctx.Tankbeurten.AsEnumerable();
        }

        public IEnumerable<Tankbeurt> All(DateTime time)
        {
            return _ctx.Tankbeurten.Where(x => (x.Datum >= time)).AsEnumerable();
        }

        public void Create(Tankbeurt t)
        {
            _ctx.Tankbeurten.Add(t);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Tankbeurten.Remove(_ctx.Tankbeurten.Find(id));
            _ctx.SaveChanges();
        }

        public Tankbeurt Find(int id)
        {
            return _ctx.Tankbeurten.Find(id);
        }

        public void Update(Tankbeurt t)
        {
            _ctx.Entry(_ctx.Tankbeurten.Find(t.TankbeurtID)).CurrentValues.SetValues(t);
            _ctx.SaveChanges();
        }
    }
}
