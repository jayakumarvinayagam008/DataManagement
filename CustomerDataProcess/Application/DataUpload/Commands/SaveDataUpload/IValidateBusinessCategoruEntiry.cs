using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IValidateBusinessCategoruEntiry
    {
        IEnumerable<int> Validate(IEnumerable<int> phoneNumbers);
    }
}
