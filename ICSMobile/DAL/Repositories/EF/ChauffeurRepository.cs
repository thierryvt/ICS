using System.Collections.Generic;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Data.Entity;
using System.Linq;
using System;

namespace DAL.Repositories.EF
{
    public class ChauffeurRepository : IChauffeurRepository
    {
        private readonly IcsContext _ctx = new IcsContext();

        public Chauffeur Find(string id)
        {
            return _ctx.Users.Find(id);
        }

        public Chauffeur FindAlleOpdrachtenRitten(string id)
        {
            //return _ctx.Users
            //    .Include(o => o.Opdrachten)
            //    .Include(o => o.Opdrachten.Select(x => x.Ritten))
            //    // .Where(o => o.Opdrachten.(r => r.Datum == DateTime.Now))
            //    .SingleOrDefault(x => (x.Id == id));

            _ctx.Configuration.LazyLoadingEnabled = false;
            var user = _ctx.Users
                           .Where(u => (u.Id == id))
                           .Select(u => new
                           {
                               User = u,
                               Opdrachten = u.Opdrachten,
                               Ritten = u.Opdrachten.SelectMany(o => o.Ritten.Where(r => r.Datum <= DateTime.Today)) 
                           })
                           .SingleOrDefault();
            return user?.User;
        }

        public IEnumerable<Chauffeur> GetAllChauffeurs()
        {
            return _ctx.Users.Include("Roles").AsEnumerable();
        }

        public void UpdateChauffeur(string id, Chauffeur c)
        {
            _ctx.Entry(_ctx.Users.Find(id)).CurrentValues.SetValues(c);
            _ctx.SaveChanges();
        }
    }
}
