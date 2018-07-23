using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppDemo.ApiContracts.ChatApi;
using WhatsAppDemo.Models;

namespace WhatsAppDemo.Common
{
    public class ChatApiServiceBridge
    {
        public string SendWhatsAppMessage(SendMessageRequest request)
        {
            var jsonRequest = GetJsonMessageForSendMessageEndpoint(request);

            ApiProxy apiProxy = new ApiProxy();

            string response = null;
            var apiResponse = apiProxy.PostAsyncEncodedContent(ApiType.ChatApi, Constants.ChatApiSendMessagePOSTEndPoint, jsonRequest);
            if (apiResponse != null)
            {
                if (apiResponse.Result.IsSuccessStatusCode)
                {
                    var customerJsonString = apiResponse.Result.Content.ReadAsStringAsync().Result;
                    response = customerJsonString;

                }
            }
            return response;
        }

        public string SendWhatsAppImage(SendImageRequest request)
        {
            var jsonRequest = GetJsonMessageForSendImageEndpoint(request);

            ApiProxy apiProxy = new ApiProxy();

            string response = null;
            var apiResponse = apiProxy.PostAsyncEncodedContent(ApiType.ChatApi, Constants.ChatApiSendImagePOSTEndPoint, jsonRequest);
            if (apiResponse != null)
            {
                if (apiResponse.Result.IsSuccessStatusCode)
                {
                    var customerJsonString = apiResponse.Result.Content.ReadAsStringAsync().Result;
                    response = customerJsonString;

                }
            }
            return response;
        }

        public string SendWhatsAppMedia(SendMediaRequest request)
        {
            var jsonRequest = GetJsonMessageForSendMediaEndpoint(request);

            ApiProxy apiProxy = new ApiProxy();

            string response = null;
            var apiResponse = apiProxy.PostAsyncEncodedContent(ApiType.ChatApi, Constants.ChatApiSendMediaPOSTEndPoint, jsonRequest);
            if (apiResponse != null)
            {
                if (apiResponse.Result.IsSuccessStatusCode)
                {
                    var customerJsonString = apiResponse.Result.Content.ReadAsStringAsync().Result;
                    response = customerJsonString;

                }
            }
            return response;
        }

        private string GetJsonMessageForSendMessageEndpoint(SendMessageRequest request)
        {
            return JsonConvert.SerializeObject(MapToMessageRequest(request), new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        private string GetJsonMessageForSendImageEndpoint(SendImageRequest request)
        {
            return JsonConvert.SerializeObject(MapToImageRequest(request), new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        private string GetJsonMessageForSendMediaEndpoint(SendMediaRequest request)
        {
            return JsonConvert.SerializeObject(MapToMediaRequest(request), new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        private Message MapToMessageRequest(SendMessageRequest request)
        {
            return new Message
            {
                Phone = request.RecipientMobileNumber,
                body = request.Message
            };
        }

        private Image MapToImageRequest(SendImageRequest request)
        {
            return new Image
            {
                Phone = request.RecipientMobileNumber,
                body = request.Url,
                filename = request.File.FileName
            };
        }

        private Media MapToMediaRequest(SendMediaRequest request)
        {
            return new Media
            {
                Phone = request.RecipientMobileNumber,
                body = request.Url,
                filename = request.File.FileName
            };
        }
    }
}
