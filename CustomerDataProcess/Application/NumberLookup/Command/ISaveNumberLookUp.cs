using System.Collections.Generic;

namespace Application.NumberLookup.Command
{
    public interface ISaveNumberLookUp
    {
        string CreateAndSave(IEnumerable<NumberLookUpDetail> numberLookUpDetails, string rootPath);
    }
}