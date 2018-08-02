using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class CustomerDataModel
    {
        public string Numbers { get; set; }
        public string Operator { get; set; }
        public string Circle { get; set; }
        public string ClientName { get; set; }
        public string ClientBusinessVertical { get; set; }
        public string DBQuality { get; set; }
        public DateTime DateOfUse { get; set; }
        public string ClientCity { get; set; }     
    }
}
