using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VMS.DataModel.Services;

namespace VMS.DataModel.Bases
{
   public class BaseEntityDate : BaseEntity
    {
        [Required]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime? EndDate { get; set; }
    }
}
