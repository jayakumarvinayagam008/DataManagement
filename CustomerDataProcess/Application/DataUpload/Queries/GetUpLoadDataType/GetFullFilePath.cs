namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetFullFilePath : IGetFullFilePath
    {
        private string extension = ".xlsx";

        public string Get(string samplePath, string fileName) => $"{samplePath}{fileName}{extension}";
    }
}