using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UploadSummary.Command
{
    public interface ISaveUploadSummary
    {
        void Save(SaveSummaryModel saveSummaryModel);
    }
}
