﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IFileToDataModel
    {
        IEnumerable<CustomerDataModel> ReadFileData(SaveDataModel saveDataModel);

    }
}