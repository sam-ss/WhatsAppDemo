using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatesAppDemo.Common;

namespace WhatesAppDemo.RequestHandler
{

    public class ApiProxy : IApiProxy
    {

        private HttpClient CreateClient(bool addAuthHeader = false, string token = null)
        {
            var client = new HttpClient(new NativeMessageHandler());
            client.Timeout = TimeSpan.FromMilliseconds(Constant.TimeoutFotHttpsCallMilliSec);
            if (addAuthHeader)
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
            return client;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, bool addAuthHeader = false, string token = null)
        {
            using (var client = CreateClient(addAuthHeader, token))
            {
                var address = string.Format("{0}{1}", Constant.BaseUrl, url);
                return await client.DeleteAsync(address);
            }
        }

        public async Task<HttpResponseMessage> DeleteAsync<T>(string url, T data, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            var json = JsonConvert.SerializeObject(data);

            using (var client = CreateClient(addAuthHeader, token))
            {
                var address = string.Format("{0}{1}", Constant.BaseUrl, url);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage();
                request.Content = content;
                request.Method = HttpMethod.Delete;
                request.RequestUri = new Uri(address);
                response = await client.SendAsync(request).ConfigureAwait(false);
            }

            return response;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null)
        {
            HttpResponseMessage response = null;
            var cts = new CancellationTokenSource();
            try
            {
                using (var client = CreateClient(addAuthHeader, token))
                {
                    var address = string.Format("{0}{1}", Constant.BaseUrl, url);
                    response = await client.GetAsync(address, cts.Token);
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
                cts.Dispose();
            }
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data, bool addAuthHeader = false, string token = null)
        {
            var json = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = null;
            var cts = new CancellationTokenSource();
            try
            {
                using (var client = CreateClient(addAuthHeader, token))
                {
                    var address = string.Format("{0}{1}", Constant.BaseUrl, url);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(address, content, cts.Token);
                }
                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {
                cts.Dispose();
            }
        }

        public async Task<HttpResponseMessage> PostAsyncEncodedContent(string url, List<KeyValuePair<string, string>> data, bool addAuthHeader = false, string token = null)
        {
            var json = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = null;
            var cts = new CancellationTokenSource();
            try
            {
                using (var client = new HttpClient())
                {
                    var address = string.Format("{0}{1}", Constant.BaseUrl2, url);
                    //var nvc = new List<KeyValuePair<string, string>>();
                    //nvc.Add(new KeyValuePair<string, string>("Input1", "TEST2"));
                    //nvc.Add(new KeyValuePair<string, string>("Input2", "TEST2"));

                    var req = new HttpRequestMessage(HttpMethod.Post, address) { Content = new FormUrlEncodedContent(data) };
                    response = await client.SendAsync(req);
                }

                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {
                cts.Dispose();
            }
        }
        public async Task<HttpResponseMessage> PutAsync<T>(string url, T data, bool addAuthHeader = false, string token = null)
        {
            var cts = new CancellationTokenSource();
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpResponseMessage response = null;
                using (var client = CreateClient(addAuthHeader, token))
                {
                    var address = string.Format("{0}{1}", Constant.BaseUrl, url);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(address, content, cts.Token);
                }
                return response;
            }
            catch (TaskCanceledException)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout);
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
            finally
            {
                cts.Dispose();
            }
        }

        public async Task<T> ReadContentAsync<T>(HttpResponseMessage response)
        {
            var message = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(message);
            return content;
        }
    }
}
