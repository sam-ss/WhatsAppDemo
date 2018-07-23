using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.ApiContracts.ChatApi
{
    public class Messages
    {
        public string Id { get; set; }

        public string Body { get; set; }

        public string Type { get; set; }

        public string SenderName { get; set; }

        public bool FromMe { get; set; }

        public string Time { get; set; }

        public string ChatId { get; set; }

        public string MessageNumber { get; set; }
    }

    public class Ack
    {
        public string Id { get; set; }

        public string MessageNumber { get; set; }

        public string ChatId { get; set; }

        public string Status { get; set; }
    }
    public class Hook
    {
        public List<Messages> Messages { get; set; }
        public List<Ack> Ack { get; set; }
    }
}
