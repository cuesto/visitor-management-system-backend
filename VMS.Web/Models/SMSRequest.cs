using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace VMS.Web.Models
{
    public class SMSRequest
    {
        public string To { get; set; }
        public string Body { get; set; }
    }
}
