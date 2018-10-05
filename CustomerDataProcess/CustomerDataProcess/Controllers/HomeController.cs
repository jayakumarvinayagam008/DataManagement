using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerDataProcess.Models;
using Application.DataUpload.Queries.GetUpLoadDataType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Net.Http.Headers;
using Application.DataUpload.Commands.SaveDataUpload;
using Application.CustomerData.Queries;
using Application.BusinessToBusiness.Queries;
using Application.BusinessToCustomers.Queries;
using Microsoft.Extensions.Options;
using System.Threading;

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
        public HomeController(IGetUpLoadDataTypeList getUpLoadDataTypeList, ISaveUploadDataCommand saveUploadDataCommand,
                              IGetCustomerData getCustomerData, IGetBusinessToBusiness getBusinessToBusiness,
                              IGetBusinessToCustomer getBusinessToCustomer,
                              IOptions<CustomerDataProcessingSetting> appSettings,
                              IGetFileContent getFileContent)
        {
            _getUpLoadDataTypeList = getUpLoadDataTypeList;
            _saveUploadDataCommand = saveUploadDataCommand;
            _getCustomerData = getCustomerData;
            _getBusinessToBusiness = getBusinessToBusiness;
            _getBusinessToCustomer = getBusinessToCustomer;
            _appSettings = appSettings;
            _getFileContent = getFileContent;
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
                UploadTypeId = uploadDataModel.UploadTypeId
            };
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');
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

                    //async Task SaveFileToServerAsync(string filePath)
                    //{

                    //    using (var stream = new FileStream(filePath, FileMode.Create))
                    //    {
                    //        await file.CopyToAsync(stream);
                    //    }
                    //}


                }
                saveUploadModel.FilePath = filePath;
            }
            Thread.Sleep(1000);

            var saveStatus = _saveUploadDataCommand.Upload(saveUploadModel);
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

    }
}
