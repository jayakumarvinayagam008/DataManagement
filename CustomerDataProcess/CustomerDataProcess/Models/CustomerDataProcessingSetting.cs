﻿namespace CustomerDataProcess.Models
{
    public class CustomerDataProcessingSetting
    {
        public string SharePath { get; set; }
        public string SampleDownloadPath { get; set; }
        public string NumberLookup { get; set; }
        public string SearchExport { get; set; }
        public int RowRange { get; set; }
    }
}