using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModel
{
    public class CounrtyViewModel
    {
        [Display(Name = "زبان مورد نظر")]
        public int LangId { get; set; }

        [Display(Name = "مقطع تحصیلی")]
        public int DegreeId { get; set; }

        [Display(Name = "بودجه مالی")]
        public int BudgetId { get; set; }

        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "نیاز به ویزا")]
        public bool Visa { get; set; }

        [Display(Name = "نمره آیلتس")]
        public int Ielts { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تصویر پرچم")]
        public IFormFile Image { get; set; }


        public string ImageName { get; set; }
    }
}
