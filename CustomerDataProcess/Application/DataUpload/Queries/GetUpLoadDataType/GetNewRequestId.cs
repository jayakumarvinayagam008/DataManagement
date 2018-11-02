using Application.Common;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetNewRequestId : IGetNewRequestId
    {
        private readonly IGetLastBusinessRequestId _getLastBusinessRequestId;
        private readonly IGetLastCustomerRequestId _getLastCustomerRequestId;
        private readonly IGetLastCustomerDataRequestId _getLastCustomerDataRequestId;
        public GetNewRequestId(IGetLastBusinessRequestId getLastBusinessRequestId,
            IGetLastCustomerRequestId getLastCustomerRequestId,
            IGetLastCustomerDataRequestId getLastCustomerDataRequestId)
        {
            _getLastBusinessRequestId = getLastBusinessRequestId;
            _getLastCustomerRequestId = getLastCustomerRequestId;
            _getLastCustomerDataRequestId = getLastCustomerDataRequestId;

        }
        public int Get(int templateTypeId)
        {
            int requestId = 1;
            if((int)CustomerDataUploadType.BusinessToBusiness == templateTypeId)
            {
                requestId = _getLastBusinessRequestId.LastRequestId();
            }
            else if((int)CustomerDataUploadType.BusinessToCustomer == templateTypeId)
            {
                requestId = _getLastCustomerRequestId.LastRequestId();
            }
            else if((int)CustomerDataUploadType.CustomerData == templateTypeId)
            {
                requestId = _getLastCustomerDataRequestId.LastRequestId();
            }
            return ++requestId;
        }
    }
}
