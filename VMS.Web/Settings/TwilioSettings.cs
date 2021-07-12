using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace VMS.Web.Settings
{
    public class TwilioSettings
    {
        public string TWILIO_ACCOUNT_SID { get; set; }
        public string TWILIO_AUTH_TOKEN { get; set; }
        public string From { get; set; }
    }
}
