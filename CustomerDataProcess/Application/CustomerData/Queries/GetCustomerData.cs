using Application.DataUpload.Commands.SaveDataUpload;
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

        public GetCustomerData(CustomerDataManagementContext dbContext,
            IGetCustomerCities getCustomerCities,
            IGetCustomerBusinessVertical getCustomerBusinessVertical,
            IGetCustomerNetwork getCustomerNetwork,
            IGetCustomerTags getCustomerTags,
            IGetCustomerDataQuality getCustomerDataQuality)
        {
            _customerDataManagementContext = dbContext;
            _getCustomerCities = getCustomerCities;
            _getCustomerBusinessVertical = getCustomerBusinessVertical;
            _getCustomerNetwork = getCustomerNetwork;
            _getCustomerTags = getCustomerTags;
            _getCustomerDataQuality = getCustomerDataQuality;
        }

        public CustomerListDataModel Get()
        {
            var cities = _getCustomerCities.Get();
            var businessValues = _getCustomerBusinessVertical.Get();
            var network = _getCustomerNetwork.Get();
            var dataQuality = _getCustomerDataQuality.Get();
            var tags = _getCustomerTags.Get();

            var customerData = _customerDataManagementContext.CustomerDataManagement
                .OrderByDescending(x => x.CreatedDate).Take(5000)
                .Select(x => new CustomerDataModel
                {
                    Circle = x.Circle,
                    ClientBusinessVertical = x.ClientBusinessVertical,
                    ClientCity = x.ClientCity,
                    ClientName = x.ClientName,
                    DateOfUse = x.DateOfUse.Value,
                    DBQuality = x.Dbquality,
                    Numbers = x.Numbers,
                    Operator = x.Operator,
                    UpdatedBy = x.CreatedBy,
                    UpdatedOn = x.CreatedDate.Value
                }).AsEnumerable<CustomerDataModel>();
            return new CustomerListDataModel
            {
                CustomerDataModels = customerData,
                Filter = new Common.DataFilter
                {
                    Cities = cities,
                    BusinessVertical = businessValues,
                    DataQuality = dataQuality,
                    Networks = network,
                    Tags = tags,
                }
            };
        }

        public CustomerListDataModel Get(CustomerDataFilter customerDataFilter)
        {
            var customerData = _customerDataManagementContext.CustomerDataManagement.AsQueryable();
            if (customerDataFilter.Cities.Any())
            {
                customerData = customerData
                                  .Where(x => customerDataFilter.Cities.Any(y => y == x.ClientCity))
                                  .AsQueryable();
            }
              
            if(customerDataFilter.BusinessVertical.Any())
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
                                        UpdatedBy = x.CreatedBy,
                                        UpdatedOn = x.CreatedDate.Value
                                    }).ToList();

            return new CustomerListDataModel
            {
                CustomerDataModels = filteredData,
                Filter = null,
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