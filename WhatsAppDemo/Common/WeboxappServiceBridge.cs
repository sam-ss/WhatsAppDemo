using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppDemo.ApiContracts;
using WhatsAppDemo.Models;
using System.Net.Http;

namespace WhatsAppDemo.Common
{
    public class WeboxappServiceBridge
    {

        public string SendWhatsAppMessage(SendMessageRequest request)
        {
            var jsonRequest = GetJsonMessageForSendMessageEndpoint(request);

            ApiProxy apiProxy = new ApiProxy();

            string response = null;
            var apiResponse = apiProxy.PostAsyncEncodedContent(Constants.SendMessagePOSTEndPoint, jsonRequest);
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
            var apiResponse = apiProxy.PostAsyncEncodedContent(Constants.SendImagePOSTEndPoint, jsonRequest);
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
            var apiResponse = apiProxy.PostAsyncEncodedContent(Constants.SendMediaPOSTEndPoint, jsonRequest);
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
            return JsonConvert.SerializeObject(MapToChatRequest(request), new JsonSerializerSettings
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

        private Chat MapToChatRequest(SendMessageRequest request)
        {
            return new Chat
            {
                Token = Constants.WeboxAppApiToken,
                Uid = request.SenderMobileNumber,
                Customer_uid = request.CustomUniqueID,
                To = request.RecipientMobileNumber,
                text = request.Message
            };
        }

        private Image MapToImageRequest(SendImageRequest request)
        {
            return new Image
            {
                Token = Constants.WeboxAppApiToken,
                Uid = request.SenderMobileNumber,
                Customer_uid = request.CustomUniqueID,
                To = request.RecipientMobileNumber,
                Url = request.Url,
                Caption = request.Caption,
                Description = request.Description
            };
        }

        private Media MapToMediaRequest(SendMediaRequest request)
        {
            return new Media
            {
                Token = Constants.WeboxAppApiToken,
                Uid = request.SenderMobileNumber,
                Customer_uid = request.CustomUniqueID,
                To = request.RecipientMobileNumber,
                Url = request.Url,
                Caption = request.Caption,
                Description = request.Description
            };
        }
    }




}
