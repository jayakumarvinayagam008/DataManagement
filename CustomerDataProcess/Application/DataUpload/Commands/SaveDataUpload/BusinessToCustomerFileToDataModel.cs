using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class BusinessToCustomerFileToDataModel : IBusinessToCustomerFileToDataModel
    {
        private Dictionary<string, int> columnIndex;
        private int totalRowCount;

        public (IEnumerable<BusinessToCustomerModel>, int) ReadFileData(SaveDataModel saveDataModel)
        {
            FileInfo fileInfo = new FileInfo(saveDataModel.FilePath);
            IEnumerable<BusinessToCustomerModel> businessToCustomerModels = null;
            if (fileInfo != null)
            {
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                    businessToCustomerModels = ReadExcelPackageToString(package, worksheet);
                    package.Dispose();
                }
            }
            return (businessToCustomerModels, totalRowCount);
        }

        private IDictionary<string, int> columnArray;

        private IEnumerable<BusinessToCustomerModel> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            totalRowCount = rowCount.Value - 1;
            var colCount = worksheet.Dimension?.Columns;
            columnIndex = new BusinessToCustomerColumnMapping().GetCustomerColumnMapping();
            IDictionary<string, int> columnHeader = new Dictionary<string, int>();
            IList<BusinessToCustomerModel> businessToCustomerModels = new List<BusinessToCustomerModel>();

            var requiredColumns = columnIndex.Select(x => x.Key.Trim()).ToArray();
            var uploadedColumns = worksheet.GetHeaderColumns();
            var allColumnExist = requiredColumns.Except(uploadedColumns).Count() == 0;

            // check column count
            if (colCount.HasValue && allColumnExist)
            {
                // fetch first row for column header
                int firstRow = 1;
                for (int col = 1; col <= colCount.Value; col++)
                {
                    columnHeader.Add($"{worksheet.Cells[firstRow, col].Value}", col);
                }

                //Featch all remain rows
                columnArray = columnHeader;
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    DateTime.TryParse($"{worksheet.Cells[row, GetColumnIndex("DOB")].Value}", out DateTime dateOfBirth);
                    int.TryParse($"{worksheet.Cells[row, GetColumnIndex("Experience")].Value}", out int experience);
                    businessToCustomerModels.Add(new BusinessToCustomerModel
                    {
                        Address = $"{worksheet.Cells[row, GetColumnIndex("Address")].Value}",
                        Address2 = $"{worksheet.Cells[row, GetColumnIndex("Address_2")].Value}",
                        AnnualSalary = $"{worksheet.Cells[row, GetColumnIndex("Annual_Salary")].Value}",
                        Area = $"{worksheet.Cells[row, GetColumnIndex("Area")].Value}",
                        Caste = $"{worksheet.Cells[row, GetColumnIndex("Caste")].Value}",
                        City = $"{worksheet.Cells[row, GetColumnIndex("City")].Value}",
                        Country = $"{worksheet.Cells[row, GetColumnIndex("Country")].Value}",
                        Dob = dateOfBirth,
                        Email = $"{worksheet.Cells[row, GetColumnIndex("Email")].Value}",
                        Employer = $"{worksheet.Cells[row, GetColumnIndex("Employer")].Value}",
                        Experience = $"{worksheet.Cells[row, GetColumnIndex("Experience")].Value}",
                        Gender = $"{worksheet.Cells[row, GetColumnIndex("Gender")].Value}",
                        Industry = $"{worksheet.Cells[row, GetColumnIndex("Industry")].Value}",
                        KeySkills = $"{worksheet.Cells[row, GetColumnIndex("Key_Skills")].Value}",
                        Location = $"{worksheet.Cells[row, GetColumnIndex("Location")].Value}",
                        Mobile2 = $"{worksheet.Cells[row, GetColumnIndex("Mobile_2")].Value}",
                        MobileNew = $"{worksheet.Cells[row, GetColumnIndex("Mobile_New")].Value}",
                        Name = $"{worksheet.Cells[row, GetColumnIndex("Name")].Value}",
                        Network = $"{worksheet.Cells[row, GetColumnIndex("Network")].Value}",
                        PhoneNew = $"{worksheet.Cells[row, GetColumnIndex("Phone_New")].Value}",
                        Pincode = $"{worksheet.Cells[row, GetColumnIndex("Pincode")].Value}",
                        Qualification = $"{worksheet.Cells[row, GetColumnIndex("Qualification")].Value}",
                        Roles = $"{worksheet.Cells[row, GetColumnIndex("Roles")].Value}",
                        State = $"{worksheet.Cells[row, GetColumnIndex("State")].Value}",
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
            if (columnArray.Keys.Any(x => x == keyName))
            {
                return columnArray[keyName];
            }
            return 0;
        }
    }
}