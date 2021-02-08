using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class DegreeViewModel
    {
        [Display(Name = "مقطع مورد نظر")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
