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
    public class OpdrachtenController : Controller
    {


        private readonly OpdrachtManager _opdrachtmanager = new OpdrachtManager();
        private readonly ChauffeurManager _chauffeurMaanger = new ChauffeurManager();
        private readonly VrachtwagenManager _vrachtwagenManager = new VrachtwagenManager();

        public ActionResult Index()
        {
            return View(_opdrachtmanager.AlleOpdrachttenMetChauffeur().ToList());
        }

        public ActionResult Lopende()
        {
            return View(_opdrachtmanager.AlleLopendeMetChauffeur().ToList());
        }

        public ActionResult Afgelopen()
        {
            return View(_opdrachtmanager.AlleAfgehandeldeOpdrachten().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_opdrachtmanager.AlleOpdrachtRitten(id));
        }

        public ActionResult Create(string nrPlaat = null, string chauffeurId = null)
        {
            PopulateVrachtwagenDropDownList(nrPlaat);
            PopulateChauffeurDropDownList(chauffeurId);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                _opdrachtmanager.CreateOpdracht(opdracht);
                return RedirectToAction("Details", new { id = opdracht.OpdrachtID });
            }

            return View(opdracht);
        }

        public ActionResult Edit(int id, string nrPlaat, string chauffeurId)
        {
            Opdracht opdracht = _opdrachtmanager.FindOpdracht(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            PopulateVrachtwagenDropDownList(nrPlaat);
            PopulateChauffeurDropDownList(chauffeurId);
            return View(opdracht);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Opdracht opdracht)
        {
            if (ModelState.IsValid)
            {
                _opdrachtmanager.UpdateOpdracht(opdracht);
                return RedirectToAction("Index");
            }
            PopulateVrachtwagenDropDownList(opdracht.ChauffeurID);
            PopulateChauffeurDropDownList(opdracht.ChauffeurID);
            return View(opdracht);
        }

        public ActionResult Delete(int id)
        {
            Opdracht opdracht = _opdrachtmanager.FindOpdracht(id);
            if (opdracht == null)
            {
                return HttpNotFound();
            }
            return View(opdracht);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _opdrachtmanager.Delete(id);
            return RedirectToAction("Index");
        }

        //todo
        private void PopulateChauffeurDropDownList(object selechtChauffeur = null)
        {
            ViewBag.Chauffeur = new SelectList(_chauffeurMaanger.AlleChauffeurs(), "Id", "FirstName", selechtChauffeur);
        }

        private void PopulateVrachtwagenDropDownList(object selectVrachtwagen = null)
        {
            ViewBag.NummerPlaat = new SelectList(_vrachtwagenManager.AlleVrachtwagenen(), "NummerPlaat", "NummerPlaat", selectVrachtwagen);
        }

    }
}
