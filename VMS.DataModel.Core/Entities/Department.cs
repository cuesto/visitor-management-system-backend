﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Core.Bases;

namespace VMS.DataModel.Core.Entities
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
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
