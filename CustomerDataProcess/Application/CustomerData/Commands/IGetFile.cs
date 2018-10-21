using Application.DataUpload.Queries.GetUpLoadDataType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Commands
{
    public interface IGetFile
    {
        SampleTemplate Get(string fileName, string type);
    }
}
