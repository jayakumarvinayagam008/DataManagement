using Application.NumberLookup.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.NumberLookup.Query
{
    public interface IGetNumberLoopUpData
    {
        IEnumerable<NumberLookUpDetail> FilterNumberLookUp(IEnumerable<Numbers> numberLookups);
    }
}
