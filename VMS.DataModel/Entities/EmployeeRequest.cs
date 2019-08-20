using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;
using VMS.DataModel.Enums;

namespace VMS.DataModel.Entities
{
    public class EmployeeRequest : BaseEntityDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeRequestKey { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeKey { get; set; }
        [StringLength(50)]
        public string VisitorName { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string VisitorEmail { get; set; }
        [StringLength(50)]
        public string VisitorPhone { get; set; }
        [StringLength(50)]
        public string TaxNumber { get; set; }
        [StringLength(50)]
        public string Company { get; set; }
        [Required]
        [ForeignKey("Purpose")]
        public int PurposeKey { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan? StartTime { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan? EndTime { get; set; }
        [StringLength(100)]
        public string Comments { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public string EmployeeName
        {
            get
            {
                if (Employee == null)
                    return "";
                return Employee.Name;
            }
        }

        [NotMapped]
        public string PurposeDescription
        {
            get
            {
                if (Purpose == null)
                    return "";
                return Purpose.Description;
            }
        }

        #region Navigation Properties
        [JsonIgnore]
        public Employee Employee { get; set; }
        [JsonIgnore]
        public Purpose Purpose { get; set; }
        #endregion

    }
}
