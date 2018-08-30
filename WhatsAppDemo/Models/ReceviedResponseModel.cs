using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Models
{
    public class ReceviedResponseModel
    {
        public string ReceivedFrom { get; set; }

        public string ReceivedFromNumber { get; set; }

        public string SendTo { get; set; }

        public string SendToNumber { get; set; }

        public string ResponseType { get; set; }

        public object Response { get; set; }

        public DateTime ReceivedAt { get; set; }

        public string ReceivedAtDisplay
        {
            get
            {
                return ReceivedAt.ToString(@"{dd/MM/yyyy hh:mm:ss tt}");
            }
        }

    }
}
