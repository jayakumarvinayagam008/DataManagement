using System.Collections.Generic;
using System.Linq;

namespace Application.Common
{
    public class UploadFileSource
    {
        private static Dictionary<int, string> filePath;

        static UploadFileSource()
        {
            filePath = new Dictionary<int, string>();
            filePath.Add((int)CustomerDataUploadType.BusinessToBusiness, "BusinessToBusiness");
            filePath.Add((int)CustomerDataUploadType.BusinessToCustomer, "BusinessToCustomer");
            filePath.Add((int)CustomerDataUploadType.CustomerData, "CustomerData");
        }

        public static string GetFileName(int typeId)
        {
            if (filePath.Keys.Any(x => x == typeId))
                return filePath[typeId];
            return string.Empty;
        }
    }
}