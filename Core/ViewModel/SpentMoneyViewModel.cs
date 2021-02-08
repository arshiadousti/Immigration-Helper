using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class SpentMoneyViewModel
    {
        [Display(Name = "میزان شهریه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Money { get; set; }
        
    }
}
