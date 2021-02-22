using System.Threading.Tasks;
using VMS.Web.Models;

namespace VMS.Web.Services
{
    public interface ITwilioService
    {
        Task SendSMSAsync(SMSRequest smsRequest);
    }
}
