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
    public class TankbeurtenController : Controller
    {

        private readonly TankbeurtManager _tankbeurtManager = new TankbeurtManager();

        public ActionResult Index()
        {
            return View(_tankbeurtManager.AlleTankbeurten().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_tankbeurtManager.FindTankbeurt(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TankbeurtID,Liter,StartKm,EindKm,NummerPlaat")] Tankbeurt tankbeurt)
        {
            if (ModelState.IsValid)
            {
                _tankbeurtManager.CreateTankbeurt(tankbeurt);
                return RedirectToAction("Details", new { id = tankbeurt.TankbeurtID });
            }

            return View(tankbeurt);
        }

        public ActionResult Edit(int id)
        {
            Tankbeurt tankbeurt = _tankbeurtManager.FindTankbeurt(id);
            if (tankbeurt == null)
            {
                return HttpNotFound();
            }
            return View(tankbeurt);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TankbeurtID,Liter,StartKm,EindKm,NummerPlaat")]Tankbeurt tankbeurt)
        {
            if (ModelState.IsValid)
            {
                _tankbeurtManager.UpdateTankbeurt(tankbeurt);
                return RedirectToAction("Index");
            }
            return View(tankbeurt);
        }

        public ActionResult Delete(int id)
        {
            Tankbeurt tankbeurt = _tankbeurtManager.FindTankbeurt(id);
            if (tankbeurt == null)
            {
                return HttpNotFound();
            }
            return View(tankbeurt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _tankbeurtManager.Delete(id);
            return RedirectToAction("Index");
        }

        //private ICSFrontEndPt2Context db = new ICSFrontEndPt2Context();

        //// GET: Tankbeurten
        //public ActionResult Index()
        //{
        //    return View(db.Tankbeurts.ToList());
        //}

        //// GET: Tankbeurten/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tankbeurt tankbeurt = db.Tankbeurts.Find(id);
        //    if (tankbeurt == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tankbeurt);
        //}

        //// GET: Tankbeurten/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Tankbeurten/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "TankbeurtID,Liter,StartKm,EindKm,NummerPlaat")] Tankbeurt tankbeurt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Tankbeurts.Add(tankbeurt);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tankbeurt);
        //}

        //// GET: Tankbeurten/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tankbeurt tankbeurt = db.Tankbeurts.Find(id);
        //    if (tankbeurt == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tankbeurt);
        //}

        //// POST: Tankbeurten/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "TankbeurtID,Liter,StartKm,EindKm,NummerPlaat")] Tankbeurt tankbeurt)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tankbeurt).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tankbeurt);
        //}

        //// GET: Tankbeurten/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tankbeurt tankbeurt = db.Tankbeurts.Find(id);
        //    if (tankbeurt == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tankbeurt);
        //}

        //// POST: Tankbeurten/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Tankbeurt tankbeurt = db.Tankbeurts.Find(id);
        //    db.Tankbeurts.Remove(tankbeurt);
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
