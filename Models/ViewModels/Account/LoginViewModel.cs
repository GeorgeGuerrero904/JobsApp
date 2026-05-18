using System.ComponentModel.DataAnnotations;

namespace JobsApp.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
