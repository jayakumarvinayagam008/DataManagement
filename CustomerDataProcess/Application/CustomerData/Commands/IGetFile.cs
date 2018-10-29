using Application.DataUpload.Queries.GetUpLoadDataType;

namespace Application.CustomerData.Commands
{
    public interface IGetFile
    {
        SampleTemplate Get(string fileName, string type);
    }
}