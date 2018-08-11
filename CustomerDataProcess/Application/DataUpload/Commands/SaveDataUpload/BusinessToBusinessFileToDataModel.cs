using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class BusinessToBusinessFileToDataModel : IBusinessToBusinessFileToDataModel
    {
        private Dictionary<string, int> columnIndex;
        public IEnumerable<BusinessToBusinesModel> ReadFileData(SaveDataModel saveDataModel)
        {
            FileInfo fileInfo = new FileInfo(saveDataModel.FilePath);
            IEnumerable<BusinessToBusinesModel> businessToBusinessModels;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                businessToBusinessModels = ReadExcelPackageToString(package, worksheet);
            }

            return businessToBusinessModels;
        }
        private IDictionary<string, int> columnArray;
        private IEnumerable<BusinessToBusinesModel> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;
            columnIndex = new BusinessToBusinessColumnMapping().GetCustomerColumnMapping();
            IDictionary<string, int> columnHeader = new Dictionary<string, int>();
            IList<BusinessToBusinesModel> businessToBusinesModels = new List<BusinessToBusinesModel>();
            // check column count
            if (colCount.HasValue && columnIndex.Count == colCount)
            {
                // fetch first row for column header
                int firstRow = 1;
                for (int col = 1; col <= colCount.Value; col++)
                {
                    columnHeader.Add($"{worksheet.Cells[firstRow, col].Value}", col);
                }
                // Check tempalate columns exist in requested customer data input
                {

                }

                //Featch all remain rows
                columnArray = columnHeader;
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    int.TryParse($"{worksheet.Cells[row, GetColumnIndex("Category ID")].Value}", out int categoryId);
                    int.TryParse($"{worksheet.Cells[row, GetColumnIndex("Est_year")].Value}", out int estYear);
                    int.TryParse($"{worksheet.Cells[row, GetColumnIndex("No_of_Emp")].Value}", out int noOfEmp);
                    businessToBusinesModels.Add(new BusinessToBusinesModel
                    {
                        Add1 = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Add2 = $"{worksheet.Cells[row, GetColumnIndex("Add2")].Value}",
                        Area = $"{worksheet.Cells[row, GetColumnIndex("Area")].Value}",
                        CategoryId = categoryId,
                        City = $"{worksheet.Cells[row, GetColumnIndex("City")].Value}",
                        CompanyName = $"{worksheet.Cells[row, GetColumnIndex("CompanyName")].Value}",
                        ContactPerson = $"{worksheet.Cells[row, GetColumnIndex("ContactPerson")].Value}",
                        Contactperson1 = $"{worksheet.Cells[row, GetColumnIndex("Contactperson1")].Value}",
                        Country = $"{worksheet.Cells[row, GetColumnIndex("Country")].Value}",
                        Designation = $"{worksheet.Cells[row, GetColumnIndex("Designation")].Value}",
                        Designation1 = $"{worksheet.Cells[row, GetColumnIndex("Designation1")].Value}",
                        Email = $"{worksheet.Cells[row, GetColumnIndex("Email")].Value}",
                        Email1 = $"{worksheet.Cells[row, GetColumnIndex("Email1")].Value}",
                        EstYear = estYear,
                        Fax = $"{worksheet.Cells[row, GetColumnIndex("Fax")].Value}",
                        LandMark = $"{worksheet.Cells[row, GetColumnIndex("LandMark")].Value}",
                        Mobile1 = $"{worksheet.Cells[row, GetColumnIndex("Mobile1")].Value}",
                        Mobile2 = $"{worksheet.Cells[row, GetColumnIndex("Mobile2")].Value}",
                        MobileNew = $"{worksheet.Cells[row, GetColumnIndex("Mobile_New")].Value}",
                        NoOfEmp = noOfEmp,
                        Phone1 = $"{worksheet.Cells[row, GetColumnIndex("Phone1")].Value}",
                        Phone2 = $"{worksheet.Cells[row, GetColumnIndex("Phone2")].Value}",
                        PhoneNew = $"{worksheet.Cells[row, GetColumnIndex("Phone_New")].Value}",
                        Pincode = $"{worksheet.Cells[row, GetColumnIndex("Pincode")].Value}",
                        State = $"{worksheet.Cells[row, GetColumnIndex("State")].Value}",
                        Web = $"{worksheet.Cells[row, GetColumnIndex("Web")].Value}"

                    });
                }
            }
            else
            {

            }
            return businessToBusinesModels.AsEnumerable<BusinessToBusinesModel>();
        }

        private int GetColumnIndex(string keyName)
        {
            if (columnArray.Keys.Any(x => x.Trim() == keyName.Trim()))
            {
                return columnArray[keyName];
            }
            return 0;
        }
    }
}
