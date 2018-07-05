using Newtonsoft.Json;
using WhatesAppDemo.Common;

namespace WhatesAppDemo.Models
{
    public class BaseApiResponse
    {
        [JsonIgnore]
        public ApiError Error { get; private set; }

        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public BaseApiResponse(string errorCode)
        {
            Error = new ApiError
            {
                ErrorCode = errorCode,
                ErrorMessage = ApiErrorCodes.GetErrorMessage(errorCode)
            };

            IsSuccess = false;
        }
    }
    public class ApiError
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("errors")]
        public System.Collections.Generic.List<string> errors { get; set; }
    }

    public class Data
    {
        public bool isAuthenticated { get; set; }
        public string message { get; set; }
        public int resultCode { get; set; }
    }
}
