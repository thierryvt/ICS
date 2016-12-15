using BL.Managers;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult ExportToExcel(string id, string naam)
        {
            XLWorkbook wb = _chauffeurManager.CreateExcel(id);
            
            // Prepare the response
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\""+ "UREN+KM_" + naam + ".xlsx\"");

            // Flush the workbook to the Response.OutputStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                wb.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                memoryStream.Close();
            }

            Response.End();
            return RedirectToAction("Index");
        }
    }
}