﻿using System;
using System.Collections.Generic;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Linq;

namespace DAL.Repositories.EF
{
    public class OpdrachtRepository : IOpdrachtRepository
    {
        private readonly IcsContext _ctx = new IcsContext();

        public IEnumerable<Opdracht> All()
        {
            return _ctx.Opdrachten.AsEnumerable();
        }

        public IEnumerable<Opdracht> All(DateTime time)
        {
            return _ctx.Opdrachten.Where(x => (x.Datum >= time)).AsEnumerable();
        }

        public void Create(Opdracht o)
        {
            _ctx.Opdrachten.Add(o);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            _ctx.Opdrachten.Remove(_ctx.Opdrachten.Find(id));
            _ctx.SaveChanges();
        }

        public Opdracht Find(int id)
        {
            return _ctx.Opdrachten.Find(id);
        }

        public void Update(int id, Opdracht o)
        {
            _ctx.Entry(_ctx.Opdrachten.Find(id)).CurrentValues.SetValues(o);
            _ctx.SaveChanges();
        }
    }
}
