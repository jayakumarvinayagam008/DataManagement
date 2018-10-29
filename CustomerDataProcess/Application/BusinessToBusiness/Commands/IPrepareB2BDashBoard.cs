using Application.BusinessToBusiness.Queries;

namespace Application.BusinessToBusiness.Commands
{
    public interface IPrepareB2BDashBoard
    {
        BusinessToBusinessDashBoard Prepare(BusinessToBusinesListModel businessToBusinesListModel);
    }
}