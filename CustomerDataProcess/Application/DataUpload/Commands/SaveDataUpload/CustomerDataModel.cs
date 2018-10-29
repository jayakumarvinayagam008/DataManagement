using System;

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
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public int CustomerDataManagementId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}