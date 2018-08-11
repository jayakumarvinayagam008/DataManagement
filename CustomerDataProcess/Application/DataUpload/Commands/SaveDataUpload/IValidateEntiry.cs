using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IValidateEntiry
    {
        IEnumerable<string> Validate(IEnumerable<string> phoneNumbers);
    }
}
