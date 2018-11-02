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
            CustomerDataColumn.Add("Client Name", 4);
            CustomerDataColumn.Add("Client Business Vertical", 5);
            CustomerDataColumn.Add("DB Quality", 6);
            CustomerDataColumn.Add("Date of Use", 7);
            CustomerDataColumn.Add("Client City", 8);
        }

        public Dictionary<string, int> GetCustomerColumnMapping()
        {
            return CustomerDataColumn;
        }
    }
}