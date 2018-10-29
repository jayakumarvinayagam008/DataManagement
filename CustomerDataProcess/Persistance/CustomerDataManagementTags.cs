﻿using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class CustomerDataManagementTags
    {
        public int CustomerDataTagId { get; set; }
        public string Tag { get; set; }
        public int? RequestId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
