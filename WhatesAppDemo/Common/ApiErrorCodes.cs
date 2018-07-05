using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatesAppDemo.Common
{
    public static class ApiErrorCodes
    {
        public static string Unauthorized = "1001";
        public static string SqliteError = "1002";
        public static string AuthFailed = "1003";
        public static string InternetConnectionLossed = "1004";
        public static string FetchingDataError = "1005";
        public static string InternalServerError = "1006";
        private static Dictionary<string, string> ErrorMessages { get; set; }
        static ApiErrorCodes()
        {
           
            ErrorMessages = new Dictionary<string, string>();
            ErrorMessages.Add(FetchingDataError, "MESSAGE_FETCHDATAERROR");
            ErrorMessages.Add(AuthFailed,"MESSAGE_AUTHFAILED");
            ErrorMessages.Add(Unauthorized,"MESSAGE_UNAUTHORIZED");
            ErrorMessages.Add(InternalServerError, "MESSAGE_INTERNALSERVERERROR");
            ErrorMessages.Add(InternetConnectionLossed, "MESSAGE_INTERNETCONNECTIONERROR");
        }

        public static string GetErrorMessage(string errorCode)
        {
            var message = string.Empty;
            if (ErrorMessages.TryGetValue(errorCode, out message))
                return message;
            return ErrorMessages[InternalServerError];
        }
    }
}
