using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppDemo.Common;

namespace WhatsAppDemo.Models
{
    public class BaseRequest
    {

        public string SenderMobileNumber
        {
            get
            {
                return Constants.SenderMobileNumber;
            }
        }
        public string RecipientMobileNumber { get; set; }

        public string CustomUniqueID
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
    }
}
