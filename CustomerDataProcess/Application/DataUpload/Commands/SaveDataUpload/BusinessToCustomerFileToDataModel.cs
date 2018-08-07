using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class BusinessToCustomerFileToDataModel : IBusinessToCustomerFileToDataModel
    {
        private Dictionary<string, int> columnIndex;
        public IEnumerable<BusinessToCustomerModel> ReadFileData(SaveDataModel saveDataModel)
        {
            FileInfo fileInfo = new FileInfo(saveDataModel.FilePath);
            IEnumerable<BusinessToCustomerModel> businessToCustomerModels;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                businessToCustomerModels = ReadExcelPackageToString(package, worksheet);
            }

            return businessToCustomerModels;
        }

        private IEnumerable<BusinessToCustomerModel> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;
            columnIndex = new BusinessToCustomerColumnMapping().GetCustomerColumnMapping();
            IList<string> columnHeader = new List<string>();
            IList<BusinessToCustomerModel> businessToCustomerModels = new List<BusinessToCustomerModel>();
            // check column count
            if (colCount.HasValue && columnIndex.Count == colCount)
            {
                // fetch first row for column header
                int firstRow = 1;
                for (int col = 1; col <= colCount.Value; col++)
                {
                    columnHeader.Add($"{worksheet.Cells[firstRow, col].Value}");
                }
                // Check tempalate columns exist in requested customer data input
                {

                }

                //Featch all remain rows
                var columnArray = columnHeader.ToArray();
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    decimal.TryParse($"{worksheet.Cells[row, GetColumnIndex("AnnualSalary")].Value}", out decimal anualsalary);
                    DateTime.TryParse($"{worksheet.Cells[row, GetColumnIndex("Dob")].Value}", out DateTime dateOfBirth);
                    int.TryParse($"{worksheet.Cells[row, GetColumnIndex("Experience")].Value}", out int experience);
                    businessToCustomerModels.Add(new BusinessToCustomerModel
                    {
                        Address = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Address2 = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        AnnualSalary = anualsalary,
                        Area = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Caste = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        City = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Country = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Dob = dateOfBirth,
                        Email = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Employer = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Experience = experience,
                        Gender = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Industry = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        KeySkills = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Location = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Mobile2 = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        MobileNew = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Name = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Network = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        PhoneNew = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Pincode = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Qualification = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        Roles = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                        State = $"{worksheet.Cells[row, GetColumnIndex("Add1")].Value}",
                    });
                }
            }
            else
            {

            }
            return businessToCustomerModels.AsEnumerable<BusinessToCustomerModel>();
        }

        private int GetColumnIndex(string keyName)
        {
            if (columnIndex.Keys.Any(x => x == keyName))
            {
                return columnIndex[keyName];
            }
            return 0;
        }
    }
}
