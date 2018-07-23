using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.ApiContracts.WeboxAppApi
{
    public class Image
    {
        public string Token { get; set; }

        public string To { get; set; }

        public string Uid { get; set; }

        public string Customer_uid { get; set; }

        public string Url { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }
    }
}
