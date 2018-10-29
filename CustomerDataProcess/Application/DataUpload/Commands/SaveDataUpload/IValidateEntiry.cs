using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IValidateEntiry
    {
        IEnumerable<string> Validate(IEnumerable<string> phoneNumbers);
    }
}