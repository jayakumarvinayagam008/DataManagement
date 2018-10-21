namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetFileContent : IGetFileContent
    {
        private readonly IGetFullFilePath _getFullFilePath;
        private readonly IGetFileName _getFileName;

        public GetFileContent(IGetFileName getFileName, IGetFullFilePath getFullFilePath)
        {
            _getFileName = getFileName;
            _getFullFilePath = getFullFilePath;
        }
        public SampleTemplate Get(int typeId, string accessPath)
        {
            var fileName = _getFileName.Get(typeId);
            var filePath = _getFullFilePath.Get(accessPath, fileName);
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var template = new SampleTemplate
                {
                    content = fileBytes,
                    TemplateType = new UploadDataType
                    {
                        Id = typeId,
                        Name = fileName
                    }
                };
                return template;
            }
            return new SampleTemplate
            {
                content = new byte[4],
                TemplateType = new UploadDataType
                {
                    Name = "Dummy"
                }
            };
        }
        public SampleTemplate Get(string fileName, string accessPath, string downloadName= "NumberLookup")
        {
            var filePath = _getFullFilePath.Get(accessPath, fileName);
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                var template = new SampleTemplate
                {
                    content = fileBytes,
                    TemplateType = new UploadDataType
                    {                        
                        Name = downloadName
                    }
                };
                return template;
            }
            return new SampleTemplate
            {
                content = new byte[4],
                TemplateType = new UploadDataType
                {
                    Name = "Dummy"
                }
            };
        }
    }
}
