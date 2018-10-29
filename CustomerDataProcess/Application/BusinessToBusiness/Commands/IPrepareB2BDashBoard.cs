using Application.BusinessToBusiness.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Commands
{
    public interface IPrepareB2BDashBoard
    {
        BusinessToBusinessDashBoard Prepare(BusinessToBusinesListModel businessToBusinesListModel);
    }
}
