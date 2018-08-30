using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsAppDemo.Common
{
    public static class Constants
    {
        public const string SenderMobileNumber = "917718842631";

        #region WeboxAppAPI Constants 

        public const string BaseWeboxAppApi = "https://www.waboxapp.com/api";
        public const string WeboxAppApiToken = "b7d232c76a750e0933fd3becafe1203d5b3da12c05415";
        public const string WeboxAppApiSendMessagePOSTEndPoint = "/send/chat";
        public const string WeboxAppApiSendImagePOSTEndPoint = "/send/image";
        public const string WeboxAppApiSendLinkPOSTEndPoint = "/send/link";
        public const string WeboxAppApiSendMediaPOSTEndPoint = "/send/media";
        public const string WeboxAppApiHooksContainer = "weboxapihookscontainer";
        public const string WeboxAppApiMediaContainer = "weboxapimediacontainer";

        #endregion

        #region ChatAPI Constants 

        public const string BaseChatAPI = "https://eu5.chat-api.com/instance10189";
        public const string ChatApiToken = "0gbeuxgajdhb3a3u";

        public const string ChatApiSendMessagePOSTEndPoint = "/sendMessage";
        public const string ChatApiSendImagePOSTEndPoint = "/sendFile";
        public const string ChatApiSendMediaPOSTEndPoint = "/sendFile";

        public const string ChatApiHooksContainer = "chatapihookscontainer";

        #endregion


        public const string StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=whatsappchatapistorage;AccountKey=j5VmajwdxuxNOw8fp6CX2mGNUTMosW8r9rxo1oF8FoPbGQFSvg9kHHb9UkHKmeOKkF552WuIESeFrDsyo9k0fQ==;EndpointSuffix=core.windows.net";
        public const int TimeoutFotHttpsCallMilliSec = 90000;
        public const string SelfMobileNumber = "917718842631";
        public const string SelfName = "Amit Ugane";
    }
}
