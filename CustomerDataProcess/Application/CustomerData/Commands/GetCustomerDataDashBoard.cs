﻿using Application.CustomerData.Queries;
using System.Linq;

namespace Application.CustomerData.Commands
{
    public class GetCustomerDataDashBoard : IGetCustomerDataDashBoard
    {
        public CustomerDataDashBoard CalculateDashBoard(CustomerListDataModel customerListDataModel)
        {
            CustomerDataDashBoard customerDataDashBoard = new CustomerDataDashBoard()
            {
                Total = customerListDataModel.Total,

                SearchCount = customerListDataModel.SearchCount,

                City = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.ClientCity))
                .Select(x => x.ClientCity).Count() / (decimal)customerListDataModel.Total) * 100,

                Operator = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.Operator))
                .Select(x => x.Operator).Count() / (decimal)customerListDataModel.Total) * 100,

                ClientBusinessVertical = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.ClientBusinessVertical))
                .Select(x => x.ClientBusinessVertical).Count() / (decimal)customerListDataModel.Total) * 100,

                Dbquality = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.DBQuality))
                .Select(x => x.DBQuality).Count() / (decimal)customerListDataModel.Total) * 100,

                ClientName = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.ClientName))
                .Select(x => x.ClientName).Count() / (decimal)customerListDataModel.Total) * 100,

                DateOfUse = (customerListDataModel.CustomerDataModels
                .Select(x => x.DateOfUse).Count() / (decimal)customerListDataModel.Total) * 100,

                Numbers = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.Numbers))
                .Select(x => x.Numbers).Count() / (decimal)customerListDataModel.Total) * 100,

                CountryCount = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.Country))
                .Select(x => x.Country).Count() / (decimal)customerListDataModel.Total) * 100,

                StateCount = (customerListDataModel.CustomerDataModels
                .Where(x => !string.IsNullOrWhiteSpace(x.State))
                .Select(x => x.State).Count() / (decimal)customerListDataModel.Total) * 100,
            };
            return customerDataDashBoard;
        }
    }
}