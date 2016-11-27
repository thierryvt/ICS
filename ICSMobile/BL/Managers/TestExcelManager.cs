using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace OpenXmlExcelFillTablePivotTable
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Copy("template.xlsx", "generated.xlsx", true);
            //Open the copied template workbook. 
            using (SpreadsheetDocument myWorkbook = SpreadsheetDocument.Open("generated.xlsx", true))
            {


                // Access the main Workbook part, which contains all references.
                WorkbookPart workbookPart = myWorkbook.WorkbookPart;
                // get sheet by name
                Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == "Sheet1").FirstOrDefault();

                if (sheet != null)
                {
                    // get worksheetpart by sheet id
                    WorksheetPart worksheetPart = workbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;
                    // get table in Sheet1
                    if (worksheetPart.TableDefinitionParts.Count() != 0)
                    {
                        // The SheetData object will contain all the data.
                        SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                        //Connect to database.
                        //DataClasses1DataContext db = new DataClasses1DataContext();

                        //The data starts at row 2. 
                        int index = 2;

                        //Select all rows from SalesTerritory table.
                        //var territoryQuery = from t in db.SalesTerritories select t;

                        //For each row in the database, add a row to they spreadsheet.
                        //foreach (var item in territoryQuery)
                        //{
                        string territoryName = "test cell data";//item.Name;
                            decimal salesLastYear = 510;//Math.Round(item.SalesLastYear, 2);
                            decimal salesThisYear = 59; //Math.Round(item.SalesYTD, 2);
                            //Add a new row.
                            Row contentRow = CreateContentRow(index, territoryName, salesLastYear, salesThisYear);
                            index++;
                            //Append new row to sheet data.
                            sheetData.AppendChild(contentRow);
                        //}
                    }
                }
            }
        }

        public static string[] headerColumns = new string[] { "A", "B", "C" };

        private static Row CreateContentRow(int index, string territory, decimal salesLastYear, decimal salesThisYear)
        {
            //Create the new row.
            Row r = new Row();
            r.RowIndex = (UInt32)index;
            //First cell is a text cell, so create it and append it.
            Cell firstCell = CreateTextCell(headerColumns[0], territory, index);
            r.AppendChild(firstCell);
            //Create the cells that contain the data.
            for (int i = 1; i < headerColumns.Length; i++)
            {
                Cell c = new Cell();
                c.CellReference = headerColumns[i] + index;
                CellValue v = new CellValue();
                if (i == 1)
                    v.Text = salesLastYear.ToString();
                else
                    v.Text = salesThisYear.ToString();
                c.AppendChild(v);
                r.AppendChild(c);
            }
            return r;
        }

        public static Cell CreateTextCell(string header, string text, int index)
        {
            //Create a new inline string cell.
            Cell c = new Cell();
            c.DataType = CellValues.InlineString;
            c.CellReference = header + index;
            //Add text to the text cell.
            InlineString inlineString = new InlineString();
            Text t = new Text();
            t.Text = text;
            inlineString.AppendChild(t);
            c.AppendChild(inlineString);
            return c;
        }

    }
}