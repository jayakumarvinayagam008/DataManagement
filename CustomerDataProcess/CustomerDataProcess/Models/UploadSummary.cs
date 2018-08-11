using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcess.Models
{
    public class UploadSummary
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Summary { get; set; }
        public string ValidationMessage { get; set; }
    }
}
