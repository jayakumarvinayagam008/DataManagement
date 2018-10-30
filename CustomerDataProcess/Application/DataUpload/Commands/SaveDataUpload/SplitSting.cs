using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public static class SplitSting
    {
        public static string[] Split(string value, char expression)
        {
            return value.Split(expression);
        }
    }
}
