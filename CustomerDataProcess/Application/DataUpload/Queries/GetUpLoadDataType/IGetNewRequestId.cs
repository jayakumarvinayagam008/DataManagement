using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetNewRequestId
    {
        int Get(int templateTypeId);
    }
}
