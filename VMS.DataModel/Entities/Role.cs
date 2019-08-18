using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VMS.DataModel.Bases;

namespace VMS.DataModel.Entities
{
    public class Role : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleKey { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        #region Navigation Properties
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        #endregion
    }
}
