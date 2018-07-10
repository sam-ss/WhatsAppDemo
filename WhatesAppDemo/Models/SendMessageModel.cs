using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatesAppDemo.Models
{
   public class SendMessageModel : BaseApiResponse
    {
        [JsonProperty(PropertyName = "isAuthenticated")]
        public bool IsAuthenticated { get; set; }

        [JsonProperty(PropertyName = "message")]
        public object Message { get; set; }

        [JsonProperty(PropertyName = "resultCode")]
        public int ResultCode { get; set; }
        public SendMessageModel(string errorCode) : base(errorCode)
        {
        }
    }
}
