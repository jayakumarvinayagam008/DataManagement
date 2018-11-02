using System.Collections.Generic;

namespace Application.UploadSummary.Quires
{
    public interface IGetLatestUploadSummary
    {
        IEnumerable<UploadSummary> Get(int fetchDay);
    }
}
