using System;
using Microsoft;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelLibrary.SpreadSheet;

namespace Recearch_Pow
{
    static class Output
    {
        static public void WriteToExcel(string filename, string sheetName, object[,] array, int firstRow = 0, int firstCol = 0)
        {
            // Microsoft.Office.Interop.Excel.Application oXL = null;
            // Microsoft.Office.Interop.Excel._Workbook oWB = null;
            // Microsoft.Office.Interop.Excel._Worksheet oSheet = null;

            // try
            // {
            //     oXL = new Microsoft.Office.Interop.Excel.Application();
            //     oWB = oXL.Workbooks.Open("filename");
            //     oSheet = String.IsNullOrEmpty(sheetName) ? (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet : (Microsoft.Office.Interop.Excel._Worksheet)oWB.Worksheets[sheetName];

            //     for (int i = 0; i < array.Length; i++)
            //         for (int j = 0; j < array.Length; j++)
            //             oSheet.Cells[firstRow + i, firstCol + j] = array[i, j];

            //     oWB.Save();

            //     Console.WriteLine("done");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.ToString());
            // }
            // finally
            // {
            //     if (oWB != null)
            //     oWB.Close();
            // }

            //create new xls file
            Workbook workbook;
            Worksheet worksheet = null;
            int worksheetIndex = -1;
            

            try
            {
                workbook = Workbook.Load(filename);
            }
            catch (Exception e)
            {
                workbook = new Workbook();
            }

            for (int i = 0; i < workbook.Worksheets.Count; i++)
            {
                if (workbook.Worksheets[i].Name == sheetName)
                {
                    worksheet = workbook.Worksheets[i];
                    worksheetIndex = i;
                    break;
                }
            }
            if (worksheetIndex < 0)
                worksheet = new Worksheet(sheetName);

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    worksheet.Cells[firstRow + i, firstCol + j] = new Cell(array[i, j]);

            // worksheet.Cells[0, 1] = new Cell((short)1);
            // worksheet.Cells[2, 0] = new Cell(9999999);
            // worksheet.Cells[3, 3] = new Cell((decimal)3.45);
            // worksheet.Cells[2, 2] = new Cell("Text string");
            // worksheet.Cells[2, 4] = new Cell("Second string");
            // worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
            // worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD");
            // worksheet.Cells.ColumnWidth[0, 1] = 3000;
            if (worksheetIndex < 0)
                workbook.Worksheets.Add(worksheet);

            workbook.Save(filename);

            // open xls file
            // Worksheet sheet = book.Worksheets[0];

            // traverse cells 
            // foreach (Pair, Cell> cell in sheet.Cells)
            //     dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;

            // // traverse rows by Index
            // for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            //     Row row = sheet.Cells.GetRow(rowIndex);
            // for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
            //     Cell cell = row.GetCell(colIndex);
        }
    }
}
