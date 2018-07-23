using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.ApiContracts
{

    public class Contact
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Message
    {
        public string Dtm { get; set; }
        public string Uid { get; set; }
        public string Cuid { get; set; }
        public string Dir { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Ack { get; set; }
    }

    public class Hook
    {
        public string Event { get; set; }
        public string Token { get; set; }
        public string Uid { get; set; }
        public Contact Contact { get; set; }
        public Message Message { get; set; }
    }
}
