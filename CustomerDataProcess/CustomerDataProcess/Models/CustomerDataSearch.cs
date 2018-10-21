using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcess.Models
{
    public class CustomerDataSearch
    {
        public string[] Cities { get; set; }
        public string[] DataQuantities { get; set; }
        public string[] Tags { get; set; }
        public string[] Network { get; set; }
        public string[] BusinessVertical { get; set; }
    }
}
