﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Core.Bases;
using VMS.DataModel.Core.Enums;

namespace VMS.DataModel.Core.Entities
{
    public class EmployeeRequest : BaseEntity
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

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        public TimeSpan? BeginTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public TimeSpan? EndTime { get; set; }

        [StringLength(100)]
        public string Comments { get; set; }
        public Status Status { get; set; }

        #region Navigation Properties
        public Employee Employee { get; set; }
        public Purpose Purpose { get; set; }
        #endregion

    }
}