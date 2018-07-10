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
        public const string BaseUrl2= "https://eu8.chat-api.com/instance6081/";
        public const string TOKEN2 = "nqtjq0ffdmt0k2j9";

        public const string Send_Chat = "send/chat";
        public const string Send_Image = "send/image";
        public const string Send_Link = "send/link";
        public const string Send_Media = "send/media";
        public const string Check_Account_Status = "status/";
        public const int TimeoutFotHttpsCallMilliSec = 90000;

        public const string TOKEN = "b7d232c76a750e0933fd3becafe1203d5b3da12c05415";
        public const string UID = "918668920519";//"917718842631";//"918668920519";

        //  public static object BaseUrl { get; internal set; }

        public enum acknowledgeStatus
        {
            MESSAGE_STILL_NOT_SENT_TO_WHATSAPP_SERVERS = 0,
            MESSAGE_SENT_TO_WHATSAPP_SERVERS = 1,            MESSAGE_DELIVERED_TO_RECIPIENT = 2,            MESSAGE_READ_BY_RECIPIENT = 3
        }
    }
}
