using System.ComponentModel.DataAnnotations;

namespace PlaniT.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        //[unique]
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string JobTitle { get; set; }


        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }
}
