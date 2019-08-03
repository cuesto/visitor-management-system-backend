using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using VMS.DataModel.Core.Enums;

namespace VMS.DataModel.Core.Bases
{
    public class Base
    {
        [DefaultValue("1")]
        [HiddenInput(DisplayValue = false)]
        public virtual IsDeleted IsDeleted { get; set; }
    }
}
