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
        //private ICSFrontEndPt2Context db = new ICSFrontEndPt2Context();

        //// GET: Vrachtwagens
        //public ActionResult Index()
        //{
        //    return View(db.Vrachtwagens.ToList());
        //}

        //// GET: Vrachtwagens/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vrachtwagen vrachtwagen = db.Vrachtwagens.Find(id);
        //    if (vrachtwagen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vrachtwagen);
        //}

        //// GET: Vrachtwagens/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Vrachtwagens/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "NummerPlaat,Merk,Type,TotaalKM,DatumInDienst")] Vrachtwagen vrachtwagen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Vrachtwagens.Add(vrachtwagen);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(vrachtwagen);
        //}

        //// GET: Vrachtwagens/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vrachtwagen vrachtwagen = db.Vrachtwagens.Find(id);
        //    if (vrachtwagen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vrachtwagen);
        //}

        //// POST: Vrachtwagens/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "NummerPlaat,Merk,Type,TotaalKM,DatumInDienst")] Vrachtwagen vrachtwagen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vrachtwagen).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vrachtwagen);
        //}

        //// GET: Vrachtwagens/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vrachtwagen vrachtwagen = db.Vrachtwagens.Find(id);
        //    if (vrachtwagen == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vrachtwagen);
        //}

        //// POST: Vrachtwagens/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Vrachtwagen vrachtwagen = db.Vrachtwagens.Find(id);
        //    db.Vrachtwagens.Remove(vrachtwagen);
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
