using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class FileToDataModel : IFileToDataModel
    {
        private Dictionary<string, int> columnIndex;
        private IDictionary<string, int> columnArray;
        private int totalRows;
        public (IEnumerable<CustomerDataModel>, int) ReadFileData(SaveDataModel saveDataModel)
        {
            FileInfo fileInfo = new FileInfo(saveDataModel.FilePath);
            IEnumerable<CustomerDataModel> customerDataModels = null;
            if (fileInfo != null)
            {
                try
                {
                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                        customerDataModels = ReadExcelPackageToString(package, worksheet);
                        package.Dispose();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            
            }
            return (customerDataModels, totalRows);
        }
        private IEnumerable<CustomerDataModel> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            totalRows = rowCount.Value - 1;
            var colCount = worksheet.Dimension?.Columns;
            columnIndex = new CustomerDataColumnMapping().GetCustomerColumnMapping();
            IDictionary<string, int> columnHeader = new Dictionary<string, int>();
            IList<CustomerDataModel> customerDataModel = new List<CustomerDataModel>();
            // check column count
            if (colCount.HasValue && columnIndex.Count == colCount)
            {
                // fetch first row for column header
                int firstRow = 1;
                for (int col = 1; col <= colCount.Value; col++)
                {
                    columnHeader.Add($"{worksheet.Cells[firstRow, col].Value}".Trim(), col);
                }
                // Check tempalate columns exist in requested customer data input
                {

                }

                //Featch all remain rows
                columnArray = columnHeader;
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    DateTime.TryParse($"{worksheet.Cells[row, GetColumnIndex("Date of Use")].Value}", out DateTime dateOfUse);

                    customerDataModel.Add(new CustomerDataModel
                    {
                        Circle = $"{worksheet.Cells[row, GetColumnIndex("Circle")].Value}",
                        ClientBusinessVertical = $"{worksheet.Cells[row, GetColumnIndex("Client Business Vertical")].Value}",
                        ClientCity = $"{worksheet.Cells[row, GetColumnIndex("Client City")].Value}",
                        ClientName = $"{worksheet.Cells[row, GetColumnIndex("Client Name")].Value}",
                        DateOfUse = dateOfUse,
                        DBQuality = $"{worksheet.Cells[row, GetColumnIndex("DB Quality")].Value}",
                        Numbers = $"{worksheet.Cells[row, GetColumnIndex("Numbers")].Value}",
                        Operator = $"{worksheet.Cells[row, GetColumnIndex("Operator")].Value}"
                    });
                }
            }
            else
            {

            }
            return customerDataModel.AsEnumerable<CustomerDataModel>();
        }

        public static void GetPropValue(object src, string propName, string value)
        {
            //Type myType = typeof(CustomerDataModel);
            //PropertyInfo[] props = myType.GetProperties();
            //props.GetType().GetProperty("Circle").SetValue(props, $"{worksheet.Cells[row, GetColumnIndex("Circle")].Value}", null);

            src.GetType().GetProperty(propName).SetValue(src, value);
        }
        private int GetColumnIndex(string keyName)
        {
            if (columnArray.Keys.Any(x => x.Trim() == keyName.Trim()))
            {
                return columnArray[keyName.Trim()];
            }
            return 0;
        }
    }
}
