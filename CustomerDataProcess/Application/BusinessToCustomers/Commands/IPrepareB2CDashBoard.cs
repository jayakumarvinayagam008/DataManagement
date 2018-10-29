using Application.BusinessToCustomers.Queries;

namespace Application.BusinessToCustomers.Commands
{
    public interface IPrepareB2CDashBoard
    {
        BusinessToCustomerDashBoard Prepare(BusinessToCustomerListModel businessToBusinesListModel);
    }
}