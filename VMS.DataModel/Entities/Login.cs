using System.ComponentModel.DataAnnotations;

namespace VMS.DataModel.Entities
{
    public class Login
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
