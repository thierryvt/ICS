using System.Linq;
using System.Web.Mvc;
using Shared.Entities;
using BL.Managers;

namespace ICSFrontEndPt2.Controllers
{
    public class VrachtwagensController : Controller
    {

        private readonly VrachtwagenManager _vrachtwagenManager = new VrachtwagenManager();

        public ActionResult Index()
        {
            return View(_vrachtwagenManager.AlleVrachtwagenen().ToList());
        }

        public ActionResult Details(string id)
        {
            return View(_vrachtwagenManager.FindVrachtwagen(id));
        }

        public ActionResult Tankbeurten(string id)
        {
            return View(_vrachtwagenManager.FindVrachtwagenTankbeurten(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NummerPlaat,Merk,Type,TotaalKM,DatumInDienst")] Vrachtwagen vrachtwagen)
        {
            if (ModelState.IsValid)
            {
                _vrachtwagenManager.CreateVrachtwagen(vrachtwagen);
                return RedirectToAction("Details", new { id = vrachtwagen.NummerPlaat });
            }

            return View(vrachtwagen);
        }

        public ActionResult Edit(string id)
        {
            Vrachtwagen vrachtwagen = _vrachtwagenManager.FindVrachtwagen(id);
            if (vrachtwagen == null)
            {
                return HttpNotFound();
            }
            return View(vrachtwagen);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NummerPlaat,Merk,Type,TotaalKM,DatumInDienst")]Vrachtwagen vrachtwagen)
        {
            if (ModelState.IsValid)
            {
                _vrachtwagenManager.UpdateVrachtwagen(vrachtwagen);
                return RedirectToAction("Index");
            }
            return View(vrachtwagen);
        }

        public ActionResult Delete(string id)
        {
            Vrachtwagen vrachtwagen = _vrachtwagenManager.FindVrachtwagen(id);
            if (vrachtwagen == null)
            {
                return HttpNotFound();
            }
            return View(vrachtwagen);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _vrachtwagenManager.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
