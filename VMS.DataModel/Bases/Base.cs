using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VMS.DataModel.Enums;

namespace VMS.DataModel.Bases
{
    public class Base
    {
        [JsonIgnore]
        [DefaultValue("0")]
        [HiddenInput(DisplayValue = false)]
        public virtual IsDeleted IsDeleted { get; set; }
    }
}
