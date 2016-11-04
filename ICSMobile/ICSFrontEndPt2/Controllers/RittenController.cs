using System.Linq;
using System.Web.Mvc;
using Shared.Entities;
using BL.Managers;

namespace ICSFrontEndPt2.Controllers
{
    public class RittenController : Controller
    {
        private readonly RitManager _ritmanager = new RitManager();
        private readonly VrachtwagenManager _vrachtwagenManager = new VrachtwagenManager();
        private readonly OpdrachtManager _opdrachtManager = new OpdrachtManager();

        public ActionResult Index()
        {
            return View(_ritmanager.AlleRitten().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_ritmanager.FindRitMetChauffeur(id));
        }

        public ActionResult Create()
        {
            PopulateVrachtwagenDropDownList();
            PopulateOpdrachtDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RitID,NummerPlaat,BeginKm,EindKm,Datum,BeginTijd,EindTijd,OpdrachtID")] Rit rit)
        {
            if (ModelState.IsValid)
            {
                _ritmanager.CreateRit(rit);
                return RedirectToAction("Details", new { id = rit.RitID });
            }
            PopulateOpdrachtDropDownList(rit.OpdrachtID);
            PopulateVrachtwagenDropDownList(rit.NummerPlaat);
            return View(rit);
        }

        public ActionResult Edit(int id)
        {
            Rit rit = _ritmanager.FindRit(id);
            if (rit == null)
            {
                return HttpNotFound();
            }
            return View(rit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RitID,NummerPlaat,BeginKm,EindKm,Datum,BeginTijd,EindTijd,OpdrachtID")]Rit rit)
        {
            if (ModelState.IsValid)
            {
                _ritmanager.UpdateRit(rit);
                return RedirectToAction("Index");
            }
            return View(rit);
        }

        public ActionResult Delete(int id)
        {
            Rit rit = _ritmanager.FindRit(id);
            if (rit == null)
            {
                return HttpNotFound();
            }
            return View(rit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ritmanager.Delete(id);
            return RedirectToAction("Index");
        }

        private void PopulateVrachtwagenDropDownList(object selectVrachtwagen = null)
        {
            ViewBag.NummerPlaat = new SelectList(_vrachtwagenManager.AlleVrachtwagenen(), "NummerPlaat", "NummerPlaat", selectVrachtwagen);
        }

        private void PopulateOpdrachtDropDownList(object selectOpdracht = null)
        {
            ViewBag.OpdrachtID = new SelectList(_opdrachtManager.AlleOpdrachtten(), "OpdrachtID", "Naam", selectOpdracht);
        }
    }
}
