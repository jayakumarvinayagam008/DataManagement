using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.NumberLookup.Command
{
    public class ReadNumberLookup : IReadNumberLookup
    {
        public IEnumerable<Numbers> Read(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            IEnumerable<Numbers> numberLookup = null;
            if (fileInfo != null)
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                    numberLookup = ReadExcelPackageToString(package, worksheet);
                    package.Dispose();
                }
            }
            return numberLookup;
        }

        private IEnumerable<Numbers> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            IList<Numbers> numberLookups = new List<Numbers>();
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    var cellValue = $"{worksheet.Cells[row, 1].Value}";
                    if(CellIsValidCheck(cellValue))
                        numberLookups.Add(new Numbers { PhoneNumber = cellValue, Series = cellValue.Substring(0, 4) });
                }            
            return numberLookups;
        }

        private bool CellIsValidCheck(string cellValue)
        {
            return !string.IsNullOrWhiteSpace(cellValue);
        }
    }
}
