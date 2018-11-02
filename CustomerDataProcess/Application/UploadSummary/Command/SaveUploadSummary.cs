using Application.Common;
using Persistance;
using System;

namespace Application.UploadSummary.Command
{
    public class SaveUploadSummary : ISaveUploadSummary
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveUploadSummary(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public void Save(SaveSummaryModel saveSummaryModel)
        {

            int statusId = saveSummaryModel.SaveStatus ? (int)DataUploadStatus.Completed : (int)DataUploadStatus.Failed;
            
            _customerDataManagementContext.UploadHistoryDetail.Add(
                new UploadHistoryDetail
                {
                    ClientFileName = saveSummaryModel.ClientFileName,
                    CreatedBy = saveSummaryModel.UploadedBy,
                    CreatedDate = DateTime.Now,
                    Exception = string.Empty,
                    Path = saveSummaryModel.Path,
                    RequestId = saveSummaryModel.RequestId,
                    ServerFileName = saveSummaryModel.ServerFileName,
                    StatusId = statusId,
                    UploadTypeId = saveSummaryModel.UploadTypeId,
                    UpLoadedRows = saveSummaryModel.UploadedRows,
                    TotalRows = saveSummaryModel.TotalRows
                }
                );
            _customerDataManagementContext.SaveChanges();
        }

        
    }
}
