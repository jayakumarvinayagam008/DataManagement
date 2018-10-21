﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Commands
{
    public class CustomerDataDashBoard
    {
        public int Total { get; set; }
        public decimal City { get; set; }
        public decimal Operator { get; set; }
        public decimal ClientBusinessVertical { get; set; }
        public decimal Dbquality { get; set; }
        public decimal ClientName { get; set; }
        public decimal DateOfUse { get; set; }
        public decimal Numbers { get; set; }
        public string DownloadLink { get; set; }
    }
}
