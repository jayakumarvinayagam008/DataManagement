using Application.CustomerData.Queries;

namespace Application.CustomerData.Commands
{
    public interface IGetCustomerDataDashBoard
    {
        CustomerDataDashBoard CalculateDashBoard(CustomerListDataModel customerListDataModel);
    }
}