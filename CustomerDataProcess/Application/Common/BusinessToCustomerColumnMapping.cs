using System.Collections.Generic;

namespace Application.Common
{
    public class BusinessToCustomerColumnMapping
    {
        private Dictionary<string, int> ColumnName { get; set; }

        public BusinessToCustomerColumnMapping()
        {
            ColumnName = new Dictionary<string, int>();
            ColumnName.Add("Name", 1);
            ColumnName.Add("DOB", 2);
            ColumnName.Add("Qualification", 3);
            ColumnName.Add("Experience", 4);
            ColumnName.Add("Employer", 5);
            ColumnName.Add("Key_Skills", 6);
            ColumnName.Add("Location", 7);
            ColumnName.Add("Roles", 8);
            ColumnName.Add("Industry", 9);
            ColumnName.Add("Address", 10);
            ColumnName.Add("Address_2", 11);
            ColumnName.Add("Email", 12);
            ColumnName.Add("Phone_New", 13);
            ColumnName.Add("Mobile_New", 14);
            ColumnName.Add("Mobile_2", 15);
            ColumnName.Add("Annual_Salary", 16);
            ColumnName.Add("Pincode", 17);
            ColumnName.Add("Area", 18);
            ColumnName.Add("City", 19);
            ColumnName.Add("State", 20);
            ColumnName.Add("Country", 21);
            ColumnName.Add("Network", 22);
            ColumnName.Add("Gender", 23);
            ColumnName.Add("Caste", 24);
        }

        public Dictionary<string, int> GetCustomerColumnMapping()
        {
            return ColumnName;
        }
    }
}