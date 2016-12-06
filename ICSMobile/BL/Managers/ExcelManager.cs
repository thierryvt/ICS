using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;

namespace BL.Managers
{
    class ExcelManager
    {
        public void createExcel(List<Opdracht> o, string naam, string worksheetName)
        {
            var wb = new XLWorkbook();

            var ws = wb.Worksheets.Add(worksheetName);

            // Title
            ws.Cell("A1").Value = naam;
            ws.Cell("A3").Value = "Datum";
            ws.Cell("B3").Value = "Begin uur";
            ws.Cell("C3").Value = "Eind uur";
            ws.Cell("D3").Value = "Totaal";
            ws.Cell("E3").Value = "Begin km";
            ws.Cell("F3").Value = "Eind km";
            ws.Cell("G3").Value = "Totaal";
            ws.Cell("D1").Value = "Nr plaat";
            ws.Cell("F1").Value = o.First().NummerPlaat;

            int i = 4;
            // First Names
            foreach (Opdracht opdracht in o)
            {
                
                foreach (Rit r in opdracht.Ritten)
                {
                    ws.Cell("A" + i.ToString()).Value = r.Datum;
                    ws.Cell("B" + i.ToString()).Value = r.BeginTijd;
                    ws.Cell("C" + i.ToString()).Value = r.EindTijd;
                    ws.Cell("D" + i.ToString()).Value = (r.EindTijd - r.BeginTijd);
                    ws.Cell("E" + i.ToString()).Value = r.BeginKm;
                    ws.Cell("F" + i.ToString()).Value = r.EindKm;
                    ws.Cell("G" + i.ToString()).Value = r.EindKm - r.BeginKm;
                    i++;
                }
                

            }
            var rngTitle = ws.Range("A3:G3");
            rngTitle.Style.Font.Bold = true;
            rngTitle.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            var rngValues = ws.Range("A4:G"+i.ToString());
            rngValues.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            rngValues.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;



            wb.SaveAs("D:/Users/Dimitri/Desktop/test.xlsx");

        }
    }
}
