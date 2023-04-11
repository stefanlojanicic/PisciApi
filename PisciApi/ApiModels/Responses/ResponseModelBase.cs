namespace ApiModels.Responses
{
    public class ResponseModelBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ResponseModelBase()
        {
            IsSuccess = true;
            Message = string.Empty;
        }
    }
}
