using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VMS.DataModel.Bases;

namespace VMS.DataModel.Entities
{
    public class BlackList : BaseEntityDate
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
        [StringLength(250)]
        public string Comment { get; set; }
    }
}
