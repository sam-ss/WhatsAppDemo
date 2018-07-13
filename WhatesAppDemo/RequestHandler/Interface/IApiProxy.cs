
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WhatesAppDemo.RequestHandler
{
    public interface IApiProxy
    {
        Task<T> ReadContentAsync<T>(HttpResponseMessage response);
        Task<HttpResponseMessage> GetAsync(string url, bool addAuthHeader = false, string token = null);

        Task<HttpResponseMessage> PostAsync<T>(string url, T data, bool addAuthHeader = false, string token = null);
        Task<HttpResponseMessage> PostAsyncEncodedContent(string url, List<KeyValuePair<string, string>> data, bool addAuthHeader = false, string token = null);
        Task<HttpResponseMessage> PostAsyncEncodedContent(string url, Dictionary<string, string> data, bool addAuthHeader = false, string token = null);

        Task<HttpResponseMessage> PutAsync<T>(string url, T data, bool addAuthHeader = false, string token = null);

        Task<HttpResponseMessage> DeleteAsync(string url, bool addAuthHeader = false, string token = null);
        Task<HttpResponseMessage> DeleteAsync<T>(string url, T data, bool addAuthHeader = false, string token = null);

    }
}
