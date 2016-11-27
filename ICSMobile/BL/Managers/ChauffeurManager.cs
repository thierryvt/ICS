using System.Collections.Generic;
using Shared.Entities;
using DAL.Repositories.Contracts;
using DAL.Repositories.EF;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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


        public void CreateExcelDoc(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {

                // Access the main Workbook part, which contains all references.
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Test Sheet" };

                // The SheetData object will contain all the data.
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                ////Create a new inline string cell.
                //Cell c = new Cell();
                //c.DataType = CellValues.String;
                //c.CellReference = "A5";

                ////Add text to the text cell.
                //InlineString inlineString = new InlineString();
                //Text t = new Text();
                //t.Text = "test met cell value";
                //inlineString.AppendChild(t);
                //c.AppendChild(inlineString);

                //Row r = new Row();
                //r.Append(c);
                ////Append new row to sheet data.
                //sheetData.AppendChild(r);
                sheets.Append(sheet);

                workbookPart.Workbook.Save();
                // document.Close();


                //WorkbookPart workbookPart = document.AddWorkbookPart();
                //workbookPart.Workbook = new Workbook();

                //WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                //worksheetPart.Worksheet = new Worksheet(new SheetData());               



                //Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                //Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Test Sheet" };

                //SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                //sheetData.AppendChild(r);

                //sheets.Append(sheet);
            }
        }

        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }

        //public void createSheetTest()
        //{
        //    Report report = new Report();
        //    report.CreateExcelDoc(@"D:\DispatcherTimer\Report.xlsx");
        //}
    }
}


