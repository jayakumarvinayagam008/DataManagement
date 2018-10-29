using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IValidateBusinessCategoruEntiry
    {
        IEnumerable<int> Validate(IEnumerable<int> phoneNumbers);
    }
}