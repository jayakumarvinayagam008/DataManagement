﻿using Application.Common;
using Application.DataUpload.Commands.SaveDataUpload;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Application.CustomerData.Commands
{
    public class ExportCustomerDataByExcel : IExportCustomerDataByExcel
    {
        private string[] columns = new string[] {
                                                "Numbers",
                                                "Operator",
                                                "Circle",
                                                "Client Name",
                                                "Client Business Vertical",
                                                "DB Quality",
                                                "Date Of Use",
                                                "Client City",
                                                "Country",
                                                "State"};

        public string CreateExcel(IEnumerable<CustomerDataModel> customerDatas, string fileRootPath, int rowRange)
        {
            var sheetContainer = customerDatas.Batch(rowRange);
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

        private ExcelWorksheet AddHeader(ExcelWorksheet excelWorksheet)
        {
            int rowIndex = 1;
            for (int columnIndex = 1; columnIndex <= columns.Length; columnIndex++)
            {
                excelWorksheet.Cells[rowIndex, columnIndex].Value = columns[columnIndex - 1];
            }
            return excelWorksheet;
        }

        private ExcelWorksheet AddRows(ExcelWorksheet excelWorksheet, IEnumerable<CustomerDataModel> customerDatas)
        {
            int rowIndex = 2;
            customerDatas.ToList().ForEach(x =>
            {
                int columnIndex = 1;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Numbers;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Operator;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Circle;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.ClientName;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.ClientBusinessVertical;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.DBQuality;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.DateOfUse;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.ClientCity;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.Country;
                excelWorksheet.Cells[rowIndex, columnIndex++].Value = x.State;
                rowIndex++;
            });
            return excelWorksheet;
        }

        private string GetGUID()
        {
            Guid guid = Guid.NewGuid();
            return $"{guid.ToString()}{DateTime.Now.ToString("yyyyMMddhhmmss")}";
        }
    }
}