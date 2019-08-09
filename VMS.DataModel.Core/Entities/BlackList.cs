using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VMS.DataModel.Core.Bases;

namespace VMS.DataModel.Core.Entities
{
    public class BlackList : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlackListKey { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string TaxNumber { get; set; }
        [StringLength(100)]
        public string PurposeComment { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
