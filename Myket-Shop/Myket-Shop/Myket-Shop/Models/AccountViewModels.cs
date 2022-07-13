using System.ComponentModel.DataAnnotations;

namespace Myket_Shop.Models
{
    public class RegisterViewModel
    {
        [MaxLength(100)]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [MaxLength(200)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "تکرار کلمه عبور")]
        public string RePassword { get; set; }

    }
    public class LoginViewModel
    {
        [MaxLength(200)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه عبور")]
        public string Password { get; set; }
        [Display(Name ="مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
