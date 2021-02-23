using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;

namespace VMS.DataModel.Entities
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
        public string OfficePhone { get; set; }
        [StringLength(50)]
        public string OfficePhoneExt { get; set; }
        [StringLength(50)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(50)]
        public string MobilePhone { get; set; }
        [StringLength(50)]
        public string Comments { get; set; }
        [NotMapped]
        public string DepartmentName
        {
            get
            {
                if (Department == null)
                    return "";
                return Department.Description;
            }
        }

        [NotMapped]
        public string DisplayAutoComplete
        {
            get
            {
                if (Department == null)
                    return "";
                return $"{EmployeeId} - {Name} - {DepartmentName}";
            }
        }

        #region Navigation Properties
        [JsonIgnore]
        public Department Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<Visitor> Visitors { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
        #endregion
    }
}
