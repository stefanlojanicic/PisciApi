namespace ApiModels.Responses
{
    public class ResponseModel<T> : ResponseModelBase
    {
        public T Payload { get; set; }
    }
}
