using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using VMS.DataModel.Core.Enums;

namespace VMS.DataModel.Core.Bases
{
    public class Base
    {
        [JsonIgnore]
        [DefaultValue("0")]
        [HiddenInput(DisplayValue = false)]
        public virtual IsDeleted IsDeleted { get; set; }
    }
}
