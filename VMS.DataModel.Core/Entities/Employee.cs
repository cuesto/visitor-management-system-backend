using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Core.Bases;

namespace VMS.DataModel.Core.Entities
{
    public class Employee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeKey { get; set; }
        [StringLength(50)]
        public string EmployeeId { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentKey { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string TaxNumber { get; set; }
        [StringLength(50)]
        public string OfficePhone { get; set; }
        [StringLength(50)]
        public string OfficePhoneExt { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        [StringLength(50)]
        public string MobilePhone { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        [StringLength(100)]
        public string Image { get; set; }


        #region Navigation Properties
        public Department Department { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
        #endregion
    }
}
