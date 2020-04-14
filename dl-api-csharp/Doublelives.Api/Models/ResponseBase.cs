namespace Doublelives.Api.Models
{
    public class ResponseBase
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public bool Success { get; set; }
    }
}