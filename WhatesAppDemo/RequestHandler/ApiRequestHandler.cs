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

        public async Task<string> SendKeyValueMessage(List<KeyValuePair<string, string>> request, string url)
        {
            string response = null;
            var apiResponse = await apiProxy.PostAsyncEncodedContent(url, request);
            //var apiResponse = await apiProxy.PostAsync(url, request);
            if (apiResponse.IsSuccessStatusCode)
            {
                var customerJsonString = await apiResponse.Content.ReadAsStringAsync();
                response = customerJsonString;

            }

            return response;
        }

        public async Task<string> SendDictionaryMessage(Dictionary<string, string> request, string url)
        {
            string response = null;
            var apiResponse = await apiProxy.PostAsyncEncodedContent(url, request);
            if (apiResponse.IsSuccessStatusCode)
            {
                var customerJsonString = await apiResponse.Content.ReadAsStringAsync();
                response = customerJsonString;

            }

            return response;
        }
    }
}
