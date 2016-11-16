using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using Shared.Entities;
using BL.Managers;

namespace API.Controllers
{
    [RoutePrefix("api/vrachtwagens")]
    [AllowAnonymous]
    public class VrachtwagensController : ApiController
    {
        private readonly VrachtwagenManager _vrachtwagenManager = new VrachtwagenManager();

        // GET: api/Vrachtwagens
        //public IQueryable<Vrachtwagen> GetVrachtwagens()
        //{
        //    return Ok(_vrachtwagenManager.AlleVrachtwagenen());
        //}

        // GET: api/Vrachtwagens/5
        [Route("byId")]
        [ResponseType(typeof(Vrachtwagen))]
        public IHttpActionResult GetVrachtwagen(string id)
        {
            Vrachtwagen vrachtwagen = _vrachtwagenManager.FindVrachtwagen(id);
            if (vrachtwagen == null)
            {
                return NotFound();
            }

            return Ok(vrachtwagen);
        }



        // PUT: api/Vrachtwagens/5
        //        [ResponseType(typeof(void))]
        //        public IHttpActionResult PutVrachtwagen(string id, Vrachtwagen vrachtwagen)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            if (id != vrachtwagen.NummerPlaat)
        //            {
        //                return BadRequest();
        //            }

        //            db.Entry(vrachtwagen).State = EntityState.Modified;

        //            try
        //            {
        //                db.SaveChanges();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!VrachtwagenExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return StatusCode(HttpStatusCode.NoContent);
        //        }

        //        // POST: api/Vrachtwagens
        //        [ResponseType(typeof(Vrachtwagen))]
        //        public IHttpActionResult PostVrachtwagen(Vrachtwagen vrachtwagen)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            db.Vrachtwagens.Add(vrachtwagen);

        //            try
        //            {
        //                db.SaveChanges();
        //            }
        //            catch (DbUpdateException)
        //            {
        //                if (VrachtwagenExists(vrachtwagen.NummerPlaat))
        //                {
        //                    return Conflict();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return CreatedAtRoute("DefaultApi", new { id = vrachtwagen.NummerPlaat }, vrachtwagen);
        //        }

        //        // DELETE: api/Vrachtwagens/5
        //        [ResponseType(typeof(Vrachtwagen))]
        //        public IHttpActionResult DeleteVrachtwagen(string id)
        //        {
        //            Vrachtwagen vrachtwagen = db.Vrachtwagens.Find(id);
        //            if (vrachtwagen == null)
        //            {
        //                return NotFound();
        //            }

        //            db.Vrachtwagens.Remove(vrachtwagen);
        //            db.SaveChanges();

        //            return Ok(vrachtwagen);
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }

        //        private bool VrachtwagenExists(string id)
        //        {
        //            return db.Vrachtwagens.Count(e => e.NummerPlaat == id) > 0;
        //        }
    }
}