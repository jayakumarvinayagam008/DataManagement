using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcess.Models
{
    public class UploadDataModel
    {
        public int UploadTypeId { get; set; }
        public IEnumerable<SelectListItem> UploadDataTypes { get; set; }
    }
}
