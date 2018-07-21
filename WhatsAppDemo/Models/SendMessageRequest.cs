using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Models
{
    public class SendMessageRequest : BaseRequest
    {
        public string Message { get; set; }
    }
}
