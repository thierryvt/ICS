using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICSFrontEndPt2.Models;
using Shared.Entities;
using BL.Managers;

namespace ICSFrontEndPt2.Controllers
{
    public class RittenController : Controller
    {
        private readonly RitManager _ritmanager = new RitManager();

        public ActionResult Index()
        {
            return View(_ritmanager.AlleRitten());
        }

        // private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ritten
        //public ActionResult Index()
        //{
        //    return View(db.Rits.ToList());
        //}

        //// GET: Ritten/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Rit rit = db.Rits.Find(id);
        //    if (rit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(rit);
        //}

        //// GET: Ritten/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Ritten/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RitID,NummerPlaat,BeginKm,EindKm,Datum,BeginTijd,EindTijd,OpdrachtID")] Rit rit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Rits.Add(rit);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(rit);
        //}

        //// GET: Ritten/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Rit rit = db.Rits.Find(id);
        //    if (rit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(rit);
        //}

        //// POST: Ritten/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RitID,NummerPlaat,BeginKm,EindKm,Datum,BeginTijd,EindTijd,OpdrachtID")] Rit rit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(rit).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(rit);
        //}

        //// GET: Ritten/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Rit rit = db.Rits.Find(id);
        //    if (rit == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(rit);
        //}

        //// POST: Ritten/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Rit rit = db.Rits.Find(id);
        //    db.Rits.Remove(rit);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
