using Application.Common;

namespace Application.CustomerData.Queries
{
    public class CustomerDataFilter : SearchRequest
    {
        public string[] DataQuantities { get; set; }
        public string[] Network { get; set; }
        public string[] BusinessVertical { get; set; }
        public string[] CustomerNames { get; set; }
    }
}