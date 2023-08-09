using API.Controllers;

namespace API.Errors
{
    public class ApiDataResponse
    {

        public ApiDataResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

   private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch 
            {
                400 => "A bad request you have made",
                401 => "You are not autirize",
                404 => "No resurse found",
                500 => "Error are not good for the dark side of it",
                _ => null
            };
        }
        
    }
}