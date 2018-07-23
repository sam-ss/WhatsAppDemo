using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppDemo.Common
{
    public class ApiProxy
    {
        private HttpClient CreateClient(bool addAuthHeader = false, string token = null)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.Timeout = TimeSpan.FromMilliseconds(Constants.TimeoutFotHttpsCallMilliSec);
            if (addAuthHeader)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            return client;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var client = CreateClient(addAuthHeader, token))
                {
                    var address = string.Format("{0}{1}", Constants.BaseWeboxAppApi, url);
                    response = await client.GetAsync(address);
                }
                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {
            }
        }


        public async Task<HttpResponseMessage> PostAsyncEncodedContent(ApiType apiType, string apiEndpoint, string jsonRequest, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            try
            {
                using (var client = new HttpClient())
                {
                    string address = string.Empty;
                    if (apiType == ApiType.WeboxAppApi)
                        address = string.Format("{0}{1}", Constants.BaseWeboxAppApi, apiEndpoint);
                    else if (apiType == ApiType.ChatApi)
                        address = string.Format("{0}{1}?token={2}", Constants.BaseChatAPI, apiEndpoint, Constants.ChatApiToken);
                    var req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json") };
                    response = await client.SendAsync(req);
                }

                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {

            }
        }

    }
}
