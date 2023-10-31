using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Models.ViewModels
{
    public class UserEdit
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and Confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
