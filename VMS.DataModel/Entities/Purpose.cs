using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;

namespace VMS.DataModel.Entities
{
    public class Purpose : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurposeKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        #region Navigation Properties
        [JsonIgnore]
        public virtual ICollection<Visitor> Visitors { get; set; }
        [JsonIgnore]
        public virtual ICollection<EmployeeRequest> EmployeeRequests { get; set; }
        #endregion
    }
}
