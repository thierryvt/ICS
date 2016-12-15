using System.Collections.Generic;
using Shared.Entities;
using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using System.Linq;

namespace BL.Managers
{
    public class ChauffeurManager
    {
        private readonly IChauffeurRepository _ChauffeurRepository = new ChauffeurRepository();

        // alle chauffeurs ophalen
        public IEnumerable<Chauffeur> AlleChauffeurs()
        {
            return _ChauffeurRepository.GetAllChauffeurs();
        }

        // 1 chauffeur met al zijn opdrachten en bijhorende ritten
        public Chauffeur AlleChauffeursMetOpdrachtRitten(string id)
        {
            return _ChauffeurRepository.FindAlleOpdrachtenRitten(id);
        }

        // 1 specifieke chauffeur
        public Chauffeur FindChauffeur(string id)
        {
            return _ChauffeurRepository.Find(id);
        }

        public ClosedXML.Excel.XLWorkbook CreateExcel(string id)
        {
            ExcelManager _excelManager = new ExcelManager();
            Chauffeur test = _ChauffeurRepository.FindAlleOpdrachtenRitten(id);
            List<Opdracht> opdrachten = test.Opdrachten.ToList();
            ClosedXML.Excel.XLWorkbook wb = _excelManager.createExcel(opdrachten, test.FirstName, "chaffeurs");
            return wb;
        }
    }
}


