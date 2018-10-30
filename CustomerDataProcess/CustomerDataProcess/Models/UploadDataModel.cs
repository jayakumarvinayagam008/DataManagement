using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CustomerDataProcess.Models
{
    public class UploadDataModel
    {
        public int UploadTypeId { get; set; }
        public IEnumerable<SelectListItem> UploadDataTypes { get; set; }
        public int? StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Summary { get; set; }
        public string ValidationMessage { get; set; }
        public string Tags { get; set; }
    }
}