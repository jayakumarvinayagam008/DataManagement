using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class NumberLookup
    {
        public int LookupId { get; set; }
        public string Series { get; set; }
        public string Circle { get; set; }
        public string Operator { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
