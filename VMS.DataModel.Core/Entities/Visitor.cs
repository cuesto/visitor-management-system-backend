using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Core.Bases;
using VMS.DataModel.Core.Enums;

namespace VMS.DataModel.Core.Entities
{
    public class Visitor : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitorKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
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
        public string PurposeComment { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeKey { get; set; }

        public DateTime? DatetimeIn { get; set; }
        public DateTime? DatetimeOut { get; set; }
        //[ForeignKey("EmployeeRequest")]
        public int EmployeeRequestKey { get; set; }

        public Status Status { get; set; }

        #region Navigation Properties
        public Purpose Purpose { get; set; }
        public Employee Employee { get; set; }
        public EmployeeRequest EmployeeRequest { get; set; }
        #endregion
    }
}
