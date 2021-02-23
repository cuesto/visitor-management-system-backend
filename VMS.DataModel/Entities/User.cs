using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VMS.DataModel.Bases;

namespace VMS.DataModel.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserKey { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleKey { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public byte[] password_hash { get; set; }
        [Required]
        public byte[] password_salt { get; set; }

        [NotMapped]
        public string RoleName
        {
            get
            {
                if (Role == null)
                    return "";
                return Role.Description;
            }
        }

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public bool IsNewPassword { get; set; }

        #region Navigation Properties
        [JsonIgnore]
        public Role Role { get; set; }
        #endregion
    }
}
