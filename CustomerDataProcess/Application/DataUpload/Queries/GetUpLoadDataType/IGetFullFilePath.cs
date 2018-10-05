using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetFullFilePath
    {
        string Get(string samplePath, string fileName);
    }
}
