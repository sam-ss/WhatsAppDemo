using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatesAppDemo.Common
{
    public class Constant
    {
        public const string BaseUrl = "https://www.waboxapp.com/api/";
        public const string Send_Chat = "send/chat";
        public const string Send_Image = "send/image";
        public const string Send_Link = "send/link";
        public const string Send_Media = "send/media";
        public const string Check_Account_Status = "send/status";
        public const int TimeoutFotHttpsCallMilliSec = 90000;



        //  public static object BaseUrl { get; internal set; }

        public enum acknowledgeStatus
        {
            MESSAGE_STILL_NOT_SENT_TO_WHATSAPP_SERVERS = 0,
            MESSAGE_SENT_TO_WHATSAPP_SERVERS = 1,            MESSAGE_DELIVERED_TO_RECIPIENT = 2,            MESSAGE_READ_BY_RECIPIENT = 3
        }
    }
}
