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
        private readonly VrachtwagenManager _vrachtwagenManager = new VrachtwagenManager();

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
            PopulateVrachtwagenDropDownList();
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
            PopulateVrachtwagenDropDownList(tankbeurt.NummerPlaat);
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


        private void PopulateVrachtwagenDropDownList(object selectVrachtwagen = null)
        {
            ViewBag.NummerPlaat = new SelectList(_vrachtwagenManager.AlleVrachtwagenen(), "NummerPlaat", "NummerPlaat", selectVrachtwagen);
        }

    }
}
