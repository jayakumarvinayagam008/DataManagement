using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveBusinessToBusinessTags
    {
        bool Save(int requestId, string[] tags);
    }
}
