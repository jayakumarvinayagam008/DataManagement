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

namespace CustomerDataProcess.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetUpLoadDataTypeList _getUpLoadDataTypeList;
        private readonly ISaveUploadDataCommand _saveUploadDataCommand; 
        public HomeController(IGetUpLoadDataTypeList getUpLoadDataTypeList, ISaveUploadDataCommand saveUploadDataCommand)
        {
            _getUpLoadDataTypeList = getUpLoadDataTypeList;
            _saveUploadDataCommand = saveUploadDataCommand;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult BusinessToBusiness()
        {
            return View();
        }

        public IActionResult BusinessToCustomers()
        {
            return View();
        }

        public IActionResult CustomerData()
        {
            return View();
        }

        public IActionResult UploadUserData()
        {
            var uploadDataModel = new UploadDataModel();
            uploadDataModel.UploadDataTypes = _getUpLoadDataTypeList.Get().Select(x => new SelectListItem { Value = $"{x.Id}", Text = x.Name });
            return View(uploadDataModel);
        }

        [HttpPost]
        public IActionResult UploadUserData(UploadDataModel uploadDataModel, IList<IFormFile> files)
        {
            uploadDataModel.UploadDataTypes = _getUpLoadDataTypeList.Get().Select(x => new SelectListItem { Value = $"{x.Id}", Text = x.Name });
            uploadDataModel.UploadTypeId = uploadDataModel.UploadTypeId;
            var saveUploadModel = new SaveDataModel() {
                UploadTypeId = uploadDataModel.UploadTypeId
            };
            foreach (var file in files)
            {
                var fileName = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');
                var rootFilePath = @"F:\DataManagement\FileUpload";
                // full path to file in temp location
                var filePath = Path.GetFullPath(rootFilePath);
                // checked file types
                if (fileName.EndsWith(".xlsx") || fileName.EndsWith(".csv"))
                {
                    var dateTime = DateTime.Now;
                    filePath = $"{filePath}\\{GetGUID()}_{fileName}" ;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                }
                saveUploadModel.FilePath = filePath;
            }


            var saveStatus = _saveUploadDataCommand.Upload(saveUploadModel);

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

    }
}
