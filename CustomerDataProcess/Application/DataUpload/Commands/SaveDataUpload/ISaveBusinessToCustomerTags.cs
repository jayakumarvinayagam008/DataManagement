﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveBusinessToCustomerTags
    {
        bool Save(int requestId, string[] tags);
    }
}
