using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

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
