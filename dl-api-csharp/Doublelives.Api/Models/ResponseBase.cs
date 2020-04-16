namespace Doublelives.Api.Models
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Code = 20000;
            Success = true;
            Msg = "³É¹¦";
        }

        public int Code { get; set; }

        public string Msg { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }
    }
}