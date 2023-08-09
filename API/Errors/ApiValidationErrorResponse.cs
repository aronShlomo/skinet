namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiDataResponse

    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        
        public IEnumerable<string> Error { get; set; }
    }
}