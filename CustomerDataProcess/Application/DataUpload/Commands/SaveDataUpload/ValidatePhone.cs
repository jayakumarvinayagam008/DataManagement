using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class ValidatePhone: IValidateEntiry
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public ValidatePhone(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<string> Validate(IEnumerable<string> phoneNumbers)
        {
            IQueryable<string> phoneNumbersFromDb = _customerDataManagementContext.BusinessToBusiness
                .Select(x => x.Phone1).AsQueryable<string>();

            var phone = phoneNumbers.Where(x => !phoneNumbersFromDb.Contains(x)).AsEnumerable<string>();
            return phone;
        }
    }
}
