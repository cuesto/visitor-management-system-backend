using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.DataModel.Core.Bases
{
    public class BaseEntity : Base
    {
        [JsonIgnore]
        [HiddenInput(DisplayValue = false)]
        public DateTime? Created { get; set; }
        [JsonIgnore]
        [MaxLength(50)]
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        [HiddenInput(DisplayValue = false)]
        public DateTime? Modified { get; set; }
        [JsonIgnore]
        [HiddenInput(DisplayValue = false)]
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
