using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveBusinessToBusiness
    {
        bool Save(IEnumerable<BusinessToBusinesModel> customerToBusiness);
    }
}
