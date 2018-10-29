namespace Application.Common
{
    public class SearchRequest
    {
        public string[] Cities { get; set; }
        public int[] Tags { get; set; }
        public string[] States { get; set; }
        public string[] Countries { get; set; }
    }
}