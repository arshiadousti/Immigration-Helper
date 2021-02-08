using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class UpdateUserPanelViewModel
    {
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
    }
}
