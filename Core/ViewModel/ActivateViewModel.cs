using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class ActivateViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(6)]
        public string ActiveCode { get; set; }
    }
}
