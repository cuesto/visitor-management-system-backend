using Newtonsoft.Json.Converters;

namespace VMS.DataModel.Services
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
