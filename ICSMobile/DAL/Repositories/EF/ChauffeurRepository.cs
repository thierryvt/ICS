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
            return _ctx.Users
                .Include("Opdrachten")
                .Include("Opdrachten.Ritten")
                .SingleOrDefault(x => (x.Id == id));
        }

        public IEnumerable<Chauffeur> GetAllChauffeurs()
        {
            return _ctx.Users.Include("Roles").AsEnumerable();
        }

        public void UpdateChauffeur(string id, Shared.Entities.Chauffeur c)
        {
            _ctx.Entry(_ctx.Users.Find(id)).CurrentValues.SetValues(c);
            _ctx.SaveChanges();
        }
    }
}
