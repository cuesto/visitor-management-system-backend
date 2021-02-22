using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using VMS.Web.Models;
using VMS.Web.Settings;

namespace VMS.Web.Services
{
    public class TwilioService : ITwilioService
    {
        private readonly TwilioSettings _twilioSettings;
        public TwilioService(IOptions<TwilioSettings> mailSettings)
        {
            _twilioSettings = mailSettings.Value;
        }

        public async Task SendSMSAsync(SMSRequest smsRequest)
        {
            TwilioClient.Init(_twilioSettings.TWILIO_ACCOUNT_SID, _twilioSettings.TWILIO_AUTH_TOKEN);

            MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber(_twilioSettings.From),
                to: new Twilio.Types.PhoneNumber(smsRequest.To)
            );
        }
    }
}
