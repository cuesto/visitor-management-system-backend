using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;
using Newtonsoft.Json;

namespace VMS.DataModel.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        #region Navigation Properties
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
