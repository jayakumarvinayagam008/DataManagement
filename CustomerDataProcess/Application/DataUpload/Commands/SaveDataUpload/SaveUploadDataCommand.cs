﻿using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveUploadDataCommand : ISaveUploadDataCommand
    {
        private Dictionary<string, int> columnIndex;
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            FileInfo fileInfo = new FileInfo(saveDataModel.FilePath);
            IEnumerable<CustomerDataModel> customerDataModels;
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1]; // Tip: To access the first worksheet, try index 1, not 0
                customerDataModels = ReadExcelPackageToString(package, worksheet);
            }

            return new UploadSaveStatus();
        }

        private IEnumerable<CustomerDataModel> ReadExcelPackageToString(ExcelPackage package, ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension?.Rows;
            var colCount = worksheet.Dimension?.Columns;
            columnIndex = new CustomerDataColumnMapping().GetCustomerColumnMapping();
            IList<string> columnHeader = new List<string>();
            IList<CustomerDataModel> customerDataModel = new List<CustomerDataModel>();
            // check column count
            if (colCount.HasValue && columnIndex.Count == colCount)
            {
                // fetch first row for column header
                int firstRow = 1;
                for (int col = 1; col <= colCount.Value; col++)
                {
                    columnHeader.Add($"{worksheet.Cells[firstRow, col].Value}");
                }

                //Featch all remain rows
                var columnArray = columnHeader.ToArray();
                for (int row = 2; row <= rowCount.Value; row++)
                {
                    DateTime.TryParse($"{worksheet.Cells[row, GetColumnIndex("DateOfUse")].Value}", out DateTime dateOfUse);
                    customerDataModel.Add(new CustomerDataModel
                    {
                        Circle = $"{worksheet.Cells[row, GetColumnIndex("Circle")].Value}",
                        ClientBusinessVertical = $"{worksheet.Cells[row, GetColumnIndex("ClientBusinessVertical")].Value}",
                        ClientCity = $"{worksheet.Cells[row, GetColumnIndex("ClientCity")].Value}",
                        ClientName = $"{worksheet.Cells[row, GetColumnIndex("ClientName")].Value}",
                        DateOfUse = dateOfUse,
                        DBQuality = $"{worksheet.Cells[row, GetColumnIndex("DBQuality")].Value}",
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
