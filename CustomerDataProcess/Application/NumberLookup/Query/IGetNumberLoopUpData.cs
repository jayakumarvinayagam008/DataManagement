using Application.NumberLookup.Command;
using System.Collections.Generic;

namespace Application.NumberLookup.Query
{
    public interface IGetNumberLoopUpData
    {
        IEnumerable<NumberLookUpDetail> FilterNumberLookUp(IEnumerable<Numbers> numberLookups);
    }
}