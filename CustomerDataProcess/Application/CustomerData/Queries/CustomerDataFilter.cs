using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class CustomerDataFilter
    {
        public string[] Cities { get; set; }
        public string[] DataQuantities { get; set; }
        public string[] Tags { get; set; }
        public string[] Network { get; set; }
        public string[] BusinessVertical { get; set; }
    }
}
