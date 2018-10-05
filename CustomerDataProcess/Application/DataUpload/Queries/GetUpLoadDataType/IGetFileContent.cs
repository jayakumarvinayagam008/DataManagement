namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetFileContent
    {
        SampleTemplate Get(int typeId, string accessPath);
    }
}
