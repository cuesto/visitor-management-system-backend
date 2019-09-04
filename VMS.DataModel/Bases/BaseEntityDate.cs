using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd")]
        public DateTime EndDate { get; set; }

        [NotMapped]
        public string StartTime
        {
            get
            {
                if (StartDate == null)
                    return "";
                return StartDate.ToString("HH:mm");
            }
        }

        [NotMapped]
        public string EndTime
        {
            get
            {
                if (EndDate == null)
                    return "";
                return EndDate.ToString("HH:mm");
            }
        }
    }
}
