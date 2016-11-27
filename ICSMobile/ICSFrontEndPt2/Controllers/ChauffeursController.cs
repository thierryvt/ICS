using BL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICSFrontEndPt2.Controllers
{
    public class ChauffeursController : Controller
    {
        private readonly ChauffeurManager _chauffeurManager = new ChauffeurManager();

        public ActionResult Index()
        {
            return View(_chauffeurManager.AlleChauffeurs().ToList());
        }

        public ActionResult OpdrachtenRitten(string id)
        {
            return View(_chauffeurManager.AlleChauffeursMetOpdrachtRitten(id));
        }

        public ActionResult Details(string id)
        {
            return View(_chauffeurManager.FindChauffeur(id));
        }

        public ActionResult CreateTest()
        {
            _chauffeurManager.CreateExcelDoc("D:/Users/Dimitri/Desktop/test.xlsx");
            return View(_chauffeurManager.AlleChauffeurs().ToList());
        }
    }
}