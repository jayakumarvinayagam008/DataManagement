using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.BusinessToBusiness.Commands
{
    public class BusinessToBusinessExport : IBusinessToBusinessExport
    {
        private string[] columns = new string[] {
                                        "Add1",
                                        "Add2",
                                        "City",
                                        "Area",
                                        "Pincode",
                                        "State",
                                        "PhoneNew",
                                        "MobileNew",
                                        "Phone1",
                                        "Phone2",
                                        "Mobile1",
                                        "Mobile2",
                                        "Fax",
                                        "Email",
                                        "Email1",
                                        "Web",
                                        "ContactPerson",
                                        "Contactperson1",
                                        "Designation",
                                        "Designation1",
                                        "EstYear",
                                        "CategoryId",
                                        "LandMark",
                                        "NoOfEmp",
                                        "Country",
                                        "CompanyName"};

        public string ExportExcel(IEnumerable<BusinessToBusinesModel> businessToBusinesModels, string fileRootPath, int rowRange)
        {
            var sheetContainer = businessToBusinesModels.Batch(rowRange);
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

        private ExcelWorksheet AddRows(ExcelWorksheet excelWorksheet, IEnumerable<BusinessToBusinesModel> businessToCustomerModels)
        {
            int rowIndex = 2;
            businessToCustomerModels.ToList().ForEach(x =>
            {
                int columnIndex = 1;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Add1; // Address1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Add2; // Address2
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.City; // City
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Area; // Area
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Pincode; // Pincode
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.State; //State
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.PhoneNew; //PhoneNew
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.MobileNew; // MobileNew
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Phone1; //Phone1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Phone2; //Phone2
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Mobile1; //Mobile1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Mobile2; //Mobile2
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Fax; // Fax
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Email; //Email
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Email1; //Email1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Web; //Web
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.ContactPerson; //ContactPerson
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Contactperson1; //Contactperson1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Designation; //Designation
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Designation1; //Designation1
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.EstYear; //EstYear
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.CategoryId; //CategoryId
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.LandMark; //LandMark
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.NoOfEmp; //NoOfEmp
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Country; //Country
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.CompanyName;   //CompanyName
                rowIndex++;
            });
            return excelWorksheet;
        }
    }
}