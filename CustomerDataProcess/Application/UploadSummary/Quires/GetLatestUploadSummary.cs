using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.UploadSummary.Quires
{
    public class GetLatestUploadSummary: IGetLatestUploadSummary
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetLatestUploadSummary(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<UploadSummary> Get(int fetchDay)
        {
            var fetechDate = DateTime.Now.AddDays(-fetchDay);
            var queryResult = _customerDataManagementContext.UploadHistoryDetail
                .Where(x => x.CreatedDate.Value > fetechDate)
                .Take(1000)
                .Select(x => new UploadSummary
                {
                    ClientFileName = x.ClientFileName,
                    FilePath = x.Path,
                    RequestId = x.RequestId.Value,
                    ServerName = x.ServerFileName,
                    Status = x.Status.Status,
                    UploadedBy = x.CreatedBy,
                    UploadedOn = x.CreatedDate.Value,
                    UploadType = x.UploadType.Name,
                    RequestedRows = x.TotalRows.HasValue ? x.TotalRows.Value : 0,
                    UploadedRows = x.UpLoadedRows.HasValue ? x.UpLoadedRows.Value : 0
                }).ToList();
            return queryResult;
        }
    }
}
