using Application.DataUpload.Commands.SaveDataUpload;
using Newtonsoft.Json;
using Persistance;
using System.Linq;

namespace Application.CustomerData.Queries
{
    public class GetCustomerData : IGetCustomerData
    {
        //        -----City  ------------ |   ---Network  ----
        //---Business Vertical--- |   -----Customer Name------
        //-------Data Quality---- |   --------Tags------------
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        private readonly IGetCustomerCities _getCustomerCities;
        private readonly IGetCustomerBusinessVertical _getCustomerBusinessVertical;
        private readonly IGetCustomerNetwork _getCustomerNetwork;
        private readonly IGetCustomerTags _getCustomerTags;
        private readonly IGetCustomerDataQuality _getCustomerDataQuality;
        private readonly IGetCustomerClientNames _getCustomerClientNames;
        private readonly IFilterCustomerTags _filterCustomerTags;
        private readonly IGetStates _getStates;
        private readonly IGetCustomerCountry _getCustomerCountry;

        public GetCustomerData(CustomerDataManagementContext dbContext,
            IGetCustomerCities getCustomerCities,
            IGetCustomerBusinessVertical getCustomerBusinessVertical,
            IGetCustomerNetwork getCustomerNetwork,
            IGetCustomerTags getCustomerTags,
            IGetCustomerDataQuality getCustomerDataQuality,
            IGetCustomerClientNames getCustomerClientNames,
            IFilterCustomerTags filterCustomerTags,
            IGetStates getStates,
            IGetCustomerCountry getCustomerCountry)
        {
            _customerDataManagementContext = dbContext;
            _getCustomerCities = getCustomerCities;
            _getCustomerBusinessVertical = getCustomerBusinessVertical;
            _getCustomerNetwork = getCustomerNetwork;
            _getCustomerTags = getCustomerTags;
            _getCustomerDataQuality = getCustomerDataQuality;
            _getCustomerClientNames = getCustomerClientNames;
            _filterCustomerTags = filterCustomerTags;
            _getStates = getStates;
            _getCustomerCountry = getCustomerCountry;
        }

        public CustomerListDataModel Get()
        {
            var cities = _getCustomerCities.Get();
            var businessValues = _getCustomerBusinessVertical.Get();
            var network = _getCustomerNetwork.Get();
            var dataQuality = _getCustomerDataQuality.Get();
            var tags = _getCustomerTags.Get();
            var clientNames = _getCustomerClientNames.Get();
            var countries = _getCustomerCountry.Get();
            var staties = _getStates.Get();

            //var customerData = _customerDataManagementContext.CustomerDataManagement
            //    .OrderByDescending(x => x.CreatedDate).Take(5000)
            //    .Select(x => new CustomerDataModel
            //    {
            //        Circle = x.Circle,
            //        ClientBusinessVertical = x.ClientBusinessVertical,
            //        ClientCity = x.ClientCity,
            //        ClientName = x.ClientName,
            //        DateOfUse = x.DateOfUse.Value,
            //        DBQuality = x.Dbquality,
            //        Numbers = x.Numbers,
            //        Operator = x.Operator,
            //        UpdatedBy = x.CreatedBy,
            //        UpdatedOn = x.CreatedDate.Value
            //    }).AsEnumerable<CustomerDataModel>();
            return new CustomerListDataModel
            {
                Filter = new Common.DataFilter
                {
                    Cities = cities,
                    BusinessVertical = businessValues,
                    DataQuality = dataQuality,
                    Networks = network,
                    Tags = JsonConvert.SerializeObject(tags),
                    Customers = clientNames,
                    Countries = countries,
                    States = staties
                }
            };
        }

        public CustomerListDataModel Get(CustomerDataFilter customerDataFilter)
        {
            var customerData = _customerDataManagementContext.CustomerDataManagement.AsQueryable();
            if (customerDataFilter.Countries.Any())
            {
                customerData = customerData
                                 .Where(x => customerDataFilter.Countries.Any(y => y == x.Country))
                                 .AsQueryable();
            }

            if (customerDataFilter.States.Any())
            {
                customerData = customerData
                                 .Where(x => customerDataFilter.States.Any(y => y == x.State))
                                 .AsQueryable();
            }

            if (customerDataFilter.Cities.Any())
            {
                customerData = customerData
                                  .Where(x => customerDataFilter.Cities.Any(y => y == x.ClientCity))
                                  .AsQueryable();
            }

            if (customerDataFilter.BusinessVertical.Any())
            {
                customerData = customerData
                                    .Where(x => customerDataFilter.BusinessVertical.Any(y => y == x.ClientBusinessVertical))
                                    .AsQueryable();
            }
            if (customerDataFilter.DataQuantities.Any())
            {
                customerData = customerData
                                   .Where(x => customerDataFilter.DataQuantities.Any(y => y == x.Dbquality))
                                   .AsQueryable();
            }
            if (customerDataFilter.Network.Any())
            {
                customerData = customerData
                                  .Where(x => customerDataFilter.Network.Any(y => y == x.Operator))
                                  .AsQueryable();
            }

            if (customerDataFilter.CustomerNames.Any())
            {
                customerData = customerData
                                  .Where(x => customerDataFilter.CustomerNames.Any(y => y == x.ClientName))
                                  .AsQueryable();
            }

            // tag filter
            var tags = _filterCustomerTags.Filter(customerDataFilter.Tags).ToList();
            if (tags.Any())
            {
                customerData = customerData.Where(x => tags.Any(y => y == x.RequestId)).AsQueryable();
            }

            var filteredData = customerData.Select(x => new CustomerDataModel
            {
                Circle = x.Circle,
                ClientBusinessVertical = x.ClientBusinessVertical,
                ClientCity = x.ClientCity,
                ClientName = x.ClientName,
                DateOfUse = x.DateOfUse.Value,
                DBQuality = x.Dbquality,
                Numbers = x.Numbers,
                Operator = x.Operator,
                CustomerDataManagementId = x.Cdmid,
                Country = x.Country,
                State = x.State
            }).ToList();

            return new CustomerListDataModel
            {
                CustomerDataModels = filteredData,
                Filter = null,
                SearchCount = filteredData.Count(),
                Total = _customerDataManagementContext.CustomerDataManagement.Count()
            };
        }

        private IQueryable<CustomerDataManagement> Cities(string[] cities)
        {
            return _customerDataManagementContext.CustomerDataManagement
                 .Where(x => cities.Any(city => city == x.ClientCity));
        }

        private IQueryable<CustomerDataManagement> Network(string[] network)
        {
            return _customerDataManagementContext.CustomerDataManagement
                 .Where(x => network.Any(circle => circle == x.Circle));
        }
    }
}