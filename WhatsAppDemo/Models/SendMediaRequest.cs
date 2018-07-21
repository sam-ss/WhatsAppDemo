using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Models
{
    public class SendMediaRequest : BaseRequest
    {
        public string Url { get; set; }

        public string Caption
        {
            get
            {
                return "Demo Media";
            }
        }

        public string Description
        {
            get
            {
                return "This is a Demo Media";
            }
        }

        public IFormFile File { get; set; }
    }
}
