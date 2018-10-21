namespace Application.CustomerData.Queries
{
    public interface IGetCustomerData
    {
        CustomerListDataModel Get();

        CustomerListDataModel Get(CustomerDataFilter customerDataFilter);
    }
}