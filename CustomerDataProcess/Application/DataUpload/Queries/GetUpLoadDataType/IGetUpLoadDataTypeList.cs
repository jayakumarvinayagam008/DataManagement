﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetUpLoadDataTypeList
    {
        IList<UploadDataType> Get();
    }
}