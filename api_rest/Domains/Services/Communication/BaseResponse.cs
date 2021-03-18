namespace api_rest.Domains.Services.Communication
{
    public abstract class BaseResponse
    {
        public bool Success {get; protected set;}

        public string Massage {get; protected set;}

        public BaseResponse (bool success, string message)
        {
            Success = success;
            Massage = message; 
        }
    }
}