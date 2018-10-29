using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Application.Common;
using OfficeOpenXml;

namespace Application.BusinessToCustomers.Commands
{
    public class ExportBusinessToCustomerFilter : IExportBusinessToCustomerFilter
    {
        private string[] columns = new string[] {
                                                "Name",
                                                "Dob",
                                                "Qualification",
                                                "Experience",
                                                "Employer",
                                                "KeySkills",
                                                "Location",
                                                "Roles",
                                                "Industry",
                                                "Address",
                                                "Address2",
                                                "Email",
                                                "PhoneNew",
                                                "MobileNew",
                                                "Mobile2",
                                                "AnnualSalary",
                                                "Pincode",
                                                "Area",
                                                "City",
                                                "State",
                                                "Country",
                                                "Network",
                                                "Gender",
                                                "Caste"};
        public string CreateExcel(IEnumerable<BusinessToCustomerModel> businessToCustomerModels, string fileRootPath, int rowRange)
        {
            var sheetContainer = businessToCustomerModels.Batch(rowRange);
            int sheetIndex = 1;
            string fileType = "xlsx";
            string fileName = GetGUID();
            var filePath = $"{fileRootPath}{fileName}.{fileType}";
            FileInfo fileInfo = new FileInfo(filePath);
            foreach (var item in sheetContainer)
            {
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    var workSheet = excelPackage.Workbook.Worksheets.Add("CustomerData - " + sheetIndex++);
                    workSheet = AddHeader(workSheet);
                    workSheet = AddRows(workSheet, item);
                    excelPackage.Save();
                }
            }
            return fileName;
        }
        private string GetGUID()
        {
            Guid guid = Guid.NewGuid();
            return $"{guid.ToString()}{DateTime.Now.ToString("yyyyMMddhhmmss")}";
        }
        private ExcelWorksheet AddHeader(ExcelWorksheet excelWorksheet)
        {
            int rowIndex = 1;
            for (int columnIndex = 1; columnIndex <= columns.Length; columnIndex++)
            {
                excelWorksheet.Cells[rowIndex, columnIndex].Value = columns[columnIndex - 1];
            }
            return excelWorksheet;
        }
        private ExcelWorksheet AddRows(ExcelWorksheet excelWorksheet, IEnumerable<BusinessToCustomerModel> businessToCustomerModels)
        {
            int rowIndex = 2;
            businessToCustomerModels.ToList().ForEach(x =>
            {
                int columnIndex = 1;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Name;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = (x.Dob != DateTime.MinValue) ? string.Format("{0:MM/dd/yyyy}", x.Dob.Value) : string.Empty;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Qualification;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Experience;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Employer;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.KeySkills;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Location;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Roles;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Industry;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Address;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Address2;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Email;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.PhoneNew;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.MobileNew;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Mobile2;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.AnnualSalary;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Pincode;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Area;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.City;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.State;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Country;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Network;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Gender;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Caste;                
                rowIndex++;
            });
            return excelWorksheet;
        }
    }
}
