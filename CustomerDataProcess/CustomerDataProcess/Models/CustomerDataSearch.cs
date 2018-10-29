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
        public int[] Tags { get; set; }
        public string[] Network { get; set; }
        public string[] BusinessVertical { get; set; }
        public string[] CustomerNames { get; set; }
        public string[] Contries { get; set; }
        public string[] States { get; set; }
        public int[] Ages { get; set; }
        public string[] Area { get; set; }
        public string[] Roles { get; set; }
        public string[] Experience { get; set; }
        public string[] Salaries { get; set; }
        public string[] Designation { get; set; }
        public int[] BusinessCategoryId { get; set; }
    }
}
