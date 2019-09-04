using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;
using VMS.DataModel.Enums;

namespace VMS.DataModel.Entities
{
    public class Visitor : BaseEntityDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string TaxNumberVisitor { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(50)]
        public string Company { get; set; }
        [Required]
        [StringLength(50)]
        public string TaxNumber { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        [Required]
        [ForeignKey("Purpose")]
        public int PurposeKey { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeKey { get; set; }
        //[ForeignKey("EmployeeRequest")]
        public int EmployeeRequestKey { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public string EmployeeName
        {
            get
            {
                if (Employee== null)
                    return "";
                return Employee.Name;
            }
        }

        #region Navigation Properties
        [JsonIgnore]
        public Purpose Purpose { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        //[JsonIgnore]
        //public EmployeeRequest EmployeeRequest { get; set; }
        #endregion
    }
}
