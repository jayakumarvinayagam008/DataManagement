using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.BusinessToCustomers.Queries;

namespace Application.BusinessToCustomers.Commands
{
    public class PrepareB2CDashBoard : IPrepareB2CDashBoard
    {
        public BusinessToCustomerDashBoard Prepare(BusinessToCustomerListModel businessToCustomerListModel)
        {
            BusinessToCustomerDashBoard businessToCustomerDashBoard = new BusinessToCustomerDashBoard()
            {
                Total = businessToCustomerListModel.Total,
                SearchCount = businessToCustomerListModel.SearchCount,
                Address = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Address))
                        .Select(x => x.Address).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Address2 = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Address))
                        .Select(x => x.Address2).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                AnnualSalary = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Address))
                        .Select(x => x.Address2).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Area = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Area))
                        .Select(x => x.Area).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Caste = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Caste))
                        .Select(x => x.Caste).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                City = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.City))
                        .Select(x => x.City).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Country = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Country))
                        .Select(x => x.Country).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Dob = (businessToCustomerListModel.BusinessToCustomers
                        .Select(x => x.Dob).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Email = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Email))
                        .Select(x => x.Email).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Employer = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Employer))
                        .Select(x => x.Employer).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Experience = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Experience))
                        .Select(x => x.Experience).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Gender = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Gender))
                        .Select(x => x.Gender).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Industry = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Industry))
                        .Select(x => x.Industry).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                KeySkills = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.KeySkills))
                        .Select(x => x.KeySkills).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Location = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Location))
                        .Select(x => x.Location).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Mobile2 = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Mobile2))
                        .Select(x => x.Mobile2).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                MobileNew = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.MobileNew))
                        .Select(x => x.MobileNew).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Name = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Name))
                        .Select(x => x.Name).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Network = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Network))
                        .Select(x => x.Network).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                PhoneNew = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.PhoneNew))
                        .Select(x => x.PhoneNew).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Pincode = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Pincode))
                        .Select(x => x.Pincode).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Qualification = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Qualification))
                        .Select(x => x.Qualification).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                Roles = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.Roles))
                        .Select(x => x.Roles).Count() / (decimal)businessToCustomerListModel.Total) * 100,

                State = (businessToCustomerListModel.BusinessToCustomers.Where(x => !string.IsNullOrWhiteSpace(x.State))
                        .Select(x => x.State).Count() / (decimal)businessToCustomerListModel.Total) * 100
            };
            return businessToCustomerDashBoard;
        }
    }
}
