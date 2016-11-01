using System.Linq;
using System.Web.Mvc;
using Shared.Entities;
using BL.Managers;

namespace ICSFrontEndPt2.Controllers
{
    public class RittenController : Controller
    {
        private readonly RitManager _ritmanager = new RitManager();

        public ActionResult Index()
        {
            return View(_ritmanager.AlleRitten().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_ritmanager.FindRit(id));
        }

        public ActionResult Create()
        {
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
    }
}
