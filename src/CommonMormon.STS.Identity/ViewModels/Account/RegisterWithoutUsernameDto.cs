using System.ComponentModel.DataAnnotations;

namespace CommonMormon.STS.Identity.ViewModels.Account
{
    public class RegisterWithoutUsernameDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}







