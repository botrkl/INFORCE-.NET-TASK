using System.ComponentModel.DataAnnotations;
using URLShortener.API.Attributes;

namespace URLShortener.API.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [ComparePasswords("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
