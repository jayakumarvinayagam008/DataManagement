namespace Application.BusinessToCustomers.Queries
{
    public interface IFilterBusinessToCustomer
    {
        BusinessToCustomerListModel Search(BusinessToCustomerFilter businessToCustomerFilter);
    }
}