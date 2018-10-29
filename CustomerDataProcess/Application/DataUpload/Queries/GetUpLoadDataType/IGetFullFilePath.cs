namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetFullFilePath
    {
        string Get(string samplePath, string fileName);
    }
}