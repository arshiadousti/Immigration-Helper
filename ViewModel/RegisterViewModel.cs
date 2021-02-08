using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        [MaxLength(40)]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        public string Email { get; set; }

        //[Display(Name = "نام و نام خانوادگی")]
        //[MaxLength(40)]
        //[Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        //public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        
        [Display(Name = "تکرار کلمه عبور")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="کلمه عبور وارد شده با تکرار آن مغایرت دارد")]
        [MaxLength(30)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RePassword { get; set; }
    }
}
