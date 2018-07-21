using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Models
{
    public class SendImageRequest : BaseRequest
    {
        public string Url { get; set; }

        public string Caption
        {
            get
            {
                return "DemoImage";
            }
        }

        public string Description
        {
            get
            {
                return "This is a Demo Image";
            }
        }

        public IFormFile File { get; set; }
    }
}
