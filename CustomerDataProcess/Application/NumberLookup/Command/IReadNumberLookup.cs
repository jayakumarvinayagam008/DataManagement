using System.Collections.Generic;

namespace Application.NumberLookup.Command
{
    public interface IReadNumberLookup
    {
        IEnumerable<Numbers> Read(string filePath);
    }
}