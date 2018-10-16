using System;
using System.Collections.Generic;
using System.Text;

namespace Application.NumberLookup.Command
{
    public interface IReadNumberLookup
    {
        IEnumerable<Numbers> Read(string filePath);
    }
}
