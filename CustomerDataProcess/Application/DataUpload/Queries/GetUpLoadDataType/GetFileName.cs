using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetFileName : IGetFileName
    {
        public string Get(int typeId) => UploadFileSource.GetFileName(typeId);
    }
}
