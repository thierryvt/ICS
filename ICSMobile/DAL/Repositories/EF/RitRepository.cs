﻿using System.Collections.Generic;
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
            return _ctx.Ritten
                .Where(x => (x.Datum >= time))
                .AsEnumerable();
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

        // LastOrDefault kan niet omgezet worden naar een leesbare query dus wordt opgelost in de mananger
        public IEnumerable<Rit> FindLast(string nummerplaat)
        {
            return _ctx.Ritten
                .Where(x => (x.NummerPlaat == nummerplaat))
                .AsEnumerable();
        }

        public Rit FindMetOpdrachtChauffeur(int id)
        {
            return _ctx.Ritten
                .Include("opdracht")
                .Include("opdracht._Chauffeur")
                .SingleOrDefault(x => (x.RitID == id));
        }

        //public Rit FindMetOpdrachtVrachtwagen(int id)
        //{
        //    return _ctx.Ritten
        //        .Include("opdracht")
        //        .Include("opdracht._Vrachtwagen")
        //        .SingleOrDefault(x => (x.RitID == id));
        //}

        public void Update(Rit r)
        {
            _ctx.Entry(_ctx.Ritten.Find(r.RitID)).CurrentValues.SetValues(r);
            _ctx.SaveChanges();
        }
    }
}
