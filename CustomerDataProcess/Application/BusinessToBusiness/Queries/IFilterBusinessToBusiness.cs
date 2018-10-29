using Application.Common;

namespace Application.BusinessToBusiness.Queries
{
    public interface IFilterBusinessToBusiness
    {
        BusinessToBusinesListModel Search(BusinessToBusinessFilter businessToBusinessFilter);
    }
}