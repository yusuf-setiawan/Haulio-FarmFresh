using System.ComponentModel.DataAnnotations;

namespace Haulio.FarmFresh.Web.Models
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
}
