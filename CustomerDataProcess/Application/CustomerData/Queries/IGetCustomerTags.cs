using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public interface IGetCustomerTags
    {
        IEnumerable<Tag> Get();
    }
}