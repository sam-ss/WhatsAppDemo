using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatesAppDemo.Common;
using WhatesAppDemo.Models;

namespace WhatesAppDemo.RequestHandler
{
    public class ApiRequestHandler
    {
        IApiProxy apiProxy;
        public ApiRequestHandler()
        {
            apiProxy = new ApiProxy();
        }
        //public async Task<SendMessageModel> ProcessRequestAsync(SendMessageModel request)
        //{
        //    SendMessageModel response = null;
        //    //var user = userRepository.GetUserByEmailId(request.EmailId);
        //    var apiResponse = await apiProxy.PostAsync(Constant.Send_Chat, request);  
        //    if (apiResponse.IsSuccessStatusCode)
        //    {
        //        var customerJsonString = await apiResponse.Content.ReadAsStringAsync();

        //        var authResponse = JsonConvert.DeserializeObject<RootObject>(custome‌​rJsonString);

        //        if (authResponse.data.isAuthenticated)
        //        {
        //            response = new SendMessageModel(string.Empty);
        //            //response.AuthenticatedUser = user;
        //            response.IsAuthenticated = authResponse.data.isAuthenticated;
        //            response.IsSuccess = true;
        //        }
        //        else
        //        {
        //            response = new SendMessageModel(ApiErrorCodes.AuthFailed);
        //           // response.AuthenticatedUser = null;
        //            response.IsAuthenticated = false;
        //            response.IsSuccess = true;
        //        }
        //    }

        //    return response;
        //}


        public async Task<string> SendMessage(List<KeyValuePair<string, string>> request, string url)
        {
            string response = null;
            //var user = userRepository.GetUserByEmailId(request.EmailId);
            var apiResponse = await apiProxy.PostAsyncEncodedContent(url, request);
            if (apiResponse.IsSuccessStatusCode)
            {
                var customerJsonString = await apiResponse.Content.ReadAsStringAsync();
                response = customerJsonString;
                //var authResponse = JsonConvert.DeserializeObject<RootObject>(custome‌​rJsonString);

                //if (authResponse.data.isAuthenticated)
                //{
                //    response = new SendMessageModel(string.Empty);
                //    //response.AuthenticatedUser = user;
                //    response.IsAuthenticated = authResponse.data.isAuthenticated;
                //    response.IsSuccess = true;
                //}
                //else
                //{
                //    response = new SendMessageModel(ApiErrorCodes.AuthFailed);
                //    // response.AuthenticatedUser = null;
                //    response.IsAuthenticated = false;
                //    response.IsSuccess = true;
                //}
            }

            return response;
        }
    }
}
