using Application.Common;
using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveBusinessToBusiness
    {
        bool Save(IEnumerable<BusinessToBusinesModel> customerToBusiness, int requestId);
    }
}