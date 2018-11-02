using Application.BusinessToBusiness.Commands;
using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Commands;
using Application.BusinessToCustomers.Queries;
using Application.Common;
using Application.CustomerData.Commands;
using Application.CustomerData.Queries;
using Application.DataUpload.Commands.SaveDataUpload;
using Application.DataUpload.Queries.GetUpLoadDataType;
using Application.NumberLookup.Command;
using Application.UploadSummary.Quires;
using CustomerDataProcess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerDataProcess.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetUpLoadDataTypeList _getUpLoadDataTypeList;
        private readonly ISaveUploadDataCommand _saveUploadDataCommand;
        private readonly IGetCustomerData _getCustomerData;
        private readonly IGetBusinessToBusiness _getBusinessToBusiness;
        private readonly IGetBusinessToCustomer _getBusinessToCustomer;
        private readonly IOptions<CustomerDataProcessingSetting> _appSettings;
        private readonly IGetFileContent _getFileContent;
        private readonly ILoopupProcess _loopupProcess;
        private ILogger<HomeController> _log;
        private readonly IGetCustomerDataDashBoard _getCustomerDataDashBoard;
        private readonly IExportCustomerDataByExcel _exportCustomerDataByExcel;
        private readonly IFilterBusinessToCustomer _filterBusinessToCustomer;
        private readonly IPrepareB2CDashBoard _prepareB2CDashBoard;
        private readonly IExportBusinessToCustomerFilter _exportBusinessToCustomerFilter;
        private readonly IFilterBusinessToBusiness _filterBusinessToBusiness;
        private readonly IPrepareB2BDashBoard _prepareB2BDashBoard;
        private readonly IBusinessToBusinessExport _businessToBusinessExport;
        private readonly IGetLatestUploadSummary _getLatestUploadSummary;
        

        public HomeController(IGetUpLoadDataTypeList getUpLoadDataTypeList, ISaveUploadDataCommand saveUploadDataCommand,
                              IGetCustomerData getCustomerData, IGetBusinessToBusiness getBusinessToBusiness,
                              IGetBusinessToCustomer getBusinessToCustomer,
                              IOptions<CustomerDataProcessingSetting> appSettings,
                              IGetFileContent getFileContent,
                              ILoopupProcess loopupProcess,
                              ILogger<HomeController> log,
                              IGetCustomerDataDashBoard getCustomerDataDashBoard,
                              IExportCustomerDataByExcel exportCustomerDataByExcel,
                              IFilterBusinessToCustomer filterBusinessToCustomer,
                              IPrepareB2CDashBoard prepareB2CDashBoard,
                              IExportBusinessToCustomerFilter exportBusinessToCustomerFilter,
                              IFilterBusinessToBusiness filterBusinessToBusiness,
                              IPrepareB2BDashBoard prepareB2BDashBoard,
                              IBusinessToBusinessExport businessToBusinessExport,
                              IGetLatestUploadSummary getLatestUploadSummary)
        {
            _getUpLoadDataTypeList = getUpLoadDataTypeList;
            _saveUploadDataCommand = saveUploadDataCommand;
            _getCustomerData = getCustomerData;
            _getBusinessToBusiness = getBusinessToBusiness;
            _getBusinessToCustomer = getBusinessToCustomer;
            _appSettings = appSettings;
            _getFileContent = getFileContent;
            _loopupProcess = loopupProcess;
            _getCustomerDataDashBoard = getCustomerDataDashBoard;
            _exportCustomerDataByExcel = exportCustomerDataByExcel;
            _filterBusinessToCustomer = filterBusinessToCustomer;
            _prepareB2CDashBoard = prepareB2CDashBoard;
            _exportBusinessToCustomerFilter = exportBusinessToCustomerFilter;
            _filterBusinessToBusiness = filterBusinessToBusiness;
            _prepareB2BDashBoard = prepareB2BDashBoard;
            _businessToBusinessExport = businessToBusinessExport;
            _getLatestUploadSummary = getLatestUploadSummary;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BusinessToBusiness()
        {
            var businessToBusinessData = _getBusinessToBusiness.Get();
            return View(businessToBusinessData);
        }

        public IActionResult BusinessToCustomers()
        {
            var businessToCustomerData = _getBusinessToCustomer.Get();
            return View(businessToCustomerData);
        }

        public IActionResult CustomerData()
        {
            var customerData = _getCustomerData.Get();
            return View(customerData);
        }

        [HttpPost]
        public IActionResult CustomerData(CustomerDataSearch customerDataSearch)
        {
            var rootPath = _appSettings.Value.SearchExport;
            int rowRange = _appSettings.Value.RowRange;
            CustomerDataFilter customerDataFilter = new CustomerDataFilter()
            {
                BusinessVertical = customerDataSearch.BusinessVertical.Any() ?
                    customerDataSearch.BusinessVertical.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Cities = customerDataSearch.Cities.Any() ?
                    customerDataSearch.Cities.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                DataQuantities = customerDataSearch.DataQuantities.Any() ?
                    customerDataSearch.DataQuantities.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Network = customerDataSearch.Network.Any() ?
                    customerDataSearch.Network.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                CustomerNames = customerDataSearch.CustomerNames.Any() ?
                    customerDataSearch.CustomerNames.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Tags = customerDataSearch.Tags.Any() ?
                    customerDataSearch.Tags : new int[] { },
                Countries = customerDataSearch.Contries.Any() ?
                    customerDataSearch.Contries.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                States = customerDataSearch.States.Any() ?
                    customerDataSearch.States.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
            };
            var customerData = _getCustomerData.Get(customerDataFilter);
            var response = _getCustomerDataDashBoard.CalculateDashBoard(customerData);
            var fileName = _exportCustomerDataByExcel.CreateExcel(customerData.CustomerDataModels, rootPath, rowRange);
            response.DownloadLink = fileName;
            return Json(response);
        }

        [HttpPost]
        public IActionResult BusinessToCustomerSearch(CustomerDataSearch customerDataSearch)
        {
            var rootPath = _appSettings.Value.SearchExport;
            int rowRange = _appSettings.Value.RowRange;
            BusinessToCustomerFilter businessToCustomerFilter = new BusinessToCustomerFilter
            {
                Age = customerDataSearch.Ages.Any() ? customerDataSearch.Ages : new int[] { },
                Areas = customerDataSearch.Area.Any() ? customerDataSearch.Area.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Cities = customerDataSearch.Cities.Any() ? customerDataSearch.Cities.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Countries = customerDataSearch.Contries.Any() ? customerDataSearch.Contries.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Experience = customerDataSearch.Experience.Any() ? customerDataSearch.Experience.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Roles = customerDataSearch.Roles.Any() ? customerDataSearch.Roles.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Salaries = customerDataSearch.Salaries.Any() ? customerDataSearch.Salaries.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                States = customerDataSearch.States.Any() ? customerDataSearch.States.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Tags = customerDataSearch.Tags.Any() ? customerDataSearch.Tags : new int[] { }
            };
            var businessToCustomer = _filterBusinessToCustomer.Search(businessToCustomerFilter);
            var b2cDashboard = _prepareB2CDashBoard.Prepare(businessToCustomer);
            var fileName = _exportBusinessToCustomerFilter.CreateExcel(businessToCustomer.BusinessToCustomers, rootPath, rowRange);
            b2cDashboard.DownloadLink = fileName;
            return Json(b2cDashboard);
        }

        [HttpPost]
        public IActionResult BusinessToBusinessSearch(CustomerDataSearch business2Business)
        {
            var rootPath = _appSettings.Value.SearchExport;
            int rowRange = _appSettings.Value.RowRange;
            BusinessToBusinessFilter businessToBusinessFilter = new BusinessToBusinessFilter()
            {
                Areas = business2Business.Area.Any() ? business2Business.Area.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                BusinessCategoryId = business2Business.BusinessCategoryId.Any() ? business2Business.BusinessCategoryId.ToArray() : new int[] { },
                Cities = business2Business.Cities.Any() ? business2Business.Cities.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Countries = business2Business.Contries.Any() ? business2Business.Contries.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Designation = business2Business.Designation.Any() ? business2Business.Designation.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                States = business2Business.States.Any() ? business2Business.States.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray() : null,
                Tags = business2Business.Tags.Any() ? business2Business.Tags : new int[] { }
            };
            var businessToBusiness = _filterBusinessToBusiness.Search(businessToBusinessFilter);
            var b2bDashboard = _prepareB2BDashBoard.Prepare(businessToBusiness);
            var fileName = _businessToBusinessExport.ExportExcel(businessToBusiness.BusinessToBusiness, rootPath, rowRange);
            b2bDashboard.DownloadLink = fileName;
            return Json(b2bDashboard);
        }

        public IActionResult CustomerDataLoad()
        {
            var customerData = _getCustomerData.Get();
            return Json(customerData.CustomerDataModels);
        }

        public IActionResult UploadUserData()
        {
            var uploadDataModel = new UploadDataModel();
            uploadDataModel.UploadDataTypes = _getUpLoadDataTypeList.Get().Select(x => new SelectListItem { Value = $"{x.Id}", Text = x.Name });

            return View(uploadDataModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadUserData(UploadDataModel uploadDataModel, IList<IFormFile> files)
        {
            uploadDataModel.UploadDataTypes = _getUpLoadDataTypeList.Get().Select(x => new SelectListItem { Value = $"{x.Id}", Text = x.Name });
            uploadDataModel.UploadTypeId = uploadDataModel.UploadTypeId;
            var saveUploadModel = new SaveDataModel()
            {
                UploadTypeId = uploadDataModel.UploadTypeId,
                Tags = uploadDataModel.Tags
            };
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var rootFilePath = _appSettings.Value.SharePath;
                // full path to file in temp location
                var filePath = Path.GetFullPath(rootFilePath);
                // checked file types
                if (fileName.EndsWith(".xlsx") || fileName.EndsWith(".csv"))
                {
                    var dateTime = DateTime.Now;
                    filePath = $"{filePath}\\{GetGUID()}_{fileName}";
                    await SaveFileToServerAsync(filePath);
                    async Task SaveFileToServerAsync(string fileFullPath)
                    {
                        using (var stream = new FileStream(fileFullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
                saveUploadModel.FilePath = filePath;
                saveUploadModel.ClientFileName = fileName;
            }
            var saveStatus = _saveUploadDataCommand.Upload(saveUploadModel);
            //update tags
            uploadDataModel.StatusCode = (saveStatus.IsUploaded) ? 1 : 2;
            uploadDataModel.StatusMessage = saveStatus.StatusMessage;
            uploadDataModel.Summary = $"{saveStatus.UploadedRows} rows uploaded out of {saveStatus.TotalRows}";
            return View(uploadDataModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool IsInternetExplore(string browser)
        {
            return (browser.Trim().ToUpper() == "IE" || browser.Trim().ToUpper() == "INTERNETEXPLORER");
        }

        private string GetGUID()
        {
            Guid guid = Guid.NewGuid();
            return $"{guid.ToString()}{DateTime.Now.ToString("yyyyMMddhhmmss")}";
        }

        public ActionResult DownloadSampleTemplate(int templateId)
        {
            var sampleTempate = _getFileContent.Get(templateId, _appSettings.Value.SampleDownloadPath);
            return File(sampleTempate.content, "application/vnd.ms-excel", $"{sampleTempate.TemplateType.Name}.xlsx");
        }

        public ActionResult UploadSummary()
        {
            var uploadSummary = _getLatestUploadSummary.Get(60);
            var uploadSummaryModel = uploadSummary.Select(x => new CustomerDataProcess.Models.UploadSummary
            {
                ClientFileName = x.ClientFileName,
                FilePath = x.FilePath,
                RequestId = x.RequestId,
                ServerName = x.ServerName,
                Status = x.Status,
                UploadedBy = x.UploadedBy,
                UploadedOn = x.UploadedOn,
                UploadType = x.UploadType,
                RequestedRows = x.RequestedRows,
                UplaodedRows = x.UploadedRows
            });

            return View(uploadSummaryModel);
        }

        public ActionResult UploadNumberLookUp()
        {
            var createdFile = new NumberLookUp()
            {
                Status = false
            };
            return View(createdFile);
        }

        [HttpPost]
        public async Task<ActionResult> UploadNumberLookUp(IList<IFormFile> files)
        {
            var lookupFileName = string.Empty;
            var rootFilePath = _appSettings.Value.NumberLookup;
            // full path to file in temp location
            var filePath = Path.GetFullPath(rootFilePath);
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');

                // checked file types
                if (fileName.EndsWith(".xlsx") || fileName.EndsWith(".csv"))
                {
                    var dateTime = DateTime.Now;
                    filePath = $"{filePath}{GetGUID()}_{fileName}";
                    await SaveFileToServerAsync(filePath);

                    async Task SaveFileToServerAsync(string fileFullPath)
                    {
                        using (var stream = new FileStream(fileFullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    lookupFileName = filePath;
                }
            }
            var fileContent = _loopupProcess.Process(lookupFileName, rootFilePath);
            var createdFile = new NumberLookUp()
            {
                FileName = fileContent,
                Status = !string.IsNullOrWhiteSpace(fileContent)
            };
            return View(createdFile);
        }

        public ActionResult DownLoadNumberLookup(string fileName)
        {
            var sampleTempate = _getFileContent.Get(fileName, _appSettings.Value.NumberLookup, "Number LookUp");
            return File(sampleTempate.content, "application/vnd.ms-excel", $"{sampleTempate.TemplateType.Name}.xlsx");
        }

        public ActionResult Export(string fileName, string type, int templateType)
        {
            fileName = $"{fileName}";
            var rootPath = _appSettings.Value.SearchExport;
            var templateName = DownloadTemplateType.GetTemplateName(templateType);
            var sampleTempate = _getFileContent.Get(fileName, rootPath, templateName);
            return File(sampleTempate.content, "application/vnd.ms-excel", $"{sampleTempate.TemplateType.Name}.xlsx");
        }
    }
}