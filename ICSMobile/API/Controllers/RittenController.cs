﻿using System.Web.Http;
using BL.Managers;

namespace API.Controllers
{
    [RoutePrefix("api/ritten")]
    public class RittenController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private readonly RitManager _ritManager = new RitManager();


        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return Ok(_ritManager.AlleRitten());
        }

        [HttpGet]
        [Route("byId")]        
        [ResponseType(typeof(Rit))]
        [AllowAnonymous]
        public IHttpActionResult GetByid([FromUri]int id)
        {
            var rit = _ritManager.FindRit(id);
            if(rit == null)
            {
                return NotFound();
            } else
            {
                return Ok(rit);
            }
        }

        // GET: api/Ritten
        //public IQueryable<Rit> GetRits()
        //{
        //    return db.Rits;
        //}

        // GET: api/Ritten/5
        //[ResponseType(typeof(Rit))]
        //public IHttpActionResult GetRit(int id)
        //{
        //    Rit rit = db.Rits.Find(id);
        //    if (rit == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(rit);
        //}

        //// PUT: api/Ritten/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutRit(int id, Rit rit)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != rit.RitID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(rit).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RitExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Ritten
        //[ResponseType(typeof(Rit))]
        //public IHttpActionResult PostRit(Rit rit)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Rits.Add(rit);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = rit.RitID }, rit);
        //}

        //// DELETE: api/Ritten/5
        //[ResponseType(typeof(Rit))]
        //public IHttpActionResult DeleteRit(int id)
        //{
        //    Rit rit = db.Rits.Find(id);
        //    if (rit == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Rits.Remove(rit);
        //    db.SaveChanges();

        //    return Ok(rit);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool RitExists(int id)
        //{
        //    return db.Rits.Count(e => e.RitID == id) > 0;
        //}
    }
}