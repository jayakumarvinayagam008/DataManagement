using System.Collections.Generic;

namespace Application.Common
{
    public class CustomerDataColumnMapping
    {
        private Dictionary<string, int> CustomerDataColumn { get; set; }

        public CustomerDataColumnMapping()
        {
            CustomerDataColumn = new Dictionary<string, int>();
            CustomerDataColumn.Add("Numbers", 1);
            CustomerDataColumn.Add("Operator", 2);
            CustomerDataColumn.Add("Circle", 3);
            CustomerDataColumn.Add("ClientName", 4);
            CustomerDataColumn.Add("ClientBusinessVertical", 5);
            CustomerDataColumn.Add("DBQuality", 6);
            CustomerDataColumn.Add("DateOfUse", 7);
            CustomerDataColumn.Add("ClientCity", 8);
        }

        public Dictionary<string, int> GetCustomerColumnMapping()
        {
            return CustomerDataColumn;
        }
    }
}