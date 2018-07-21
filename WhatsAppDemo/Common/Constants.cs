using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Common
{
    public static class Constants
    {
        public const string BaseWeboxAppApi = "https://www.waboxapp.com/api";
        public const string SenderMobileNumber = "917718842631";
        public const string WeboxAppApiToken = "b7d232c76a750e0933fd3becafe1203d5b3da12c05415";
        public const string SendMessagePOSTEndPoint = "/send/chat";
        public const string SendImagePOSTEndPoint = "/send/image";
        public const string SendLinkPOSTEndPoint = "/send/link";
        public const string SendMediaPOSTEndPoint = "/send/media";
        public const int TimeoutFotHttpsCallMilliSec = 90000;

        public const string ApiHooksContainer = "weboxapihookscontainer";
        public const string ApiMediaContainer = "weboxapimediacontainer";
        public const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=whatsappchatapistorage;AccountKey=j5VmajwdxuxNOw8fp6CX2mGNUTMosW8r9rxo1oF8FoPbGQFSvg9kHHb9UkHKmeOKkF552WuIESeFrDsyo9k0fQ==;EndpointSuffix=core.windows.net";

    }
}
