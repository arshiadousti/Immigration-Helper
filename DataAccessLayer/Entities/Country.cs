using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

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
        [MaxLength(50)]
        public string Image { get; set; }

        //Navigation

        [ForeignKey("BudgetId")]
        public virtual SpentMoney SpentMoney { get; set; }

        public virtual ICollection<DegreeCountry> DegreeTests { get; set; }

        public virtual ICollection<LangCountry> LangCountries { get; set; }

        //public virtual ICollection<TestCountry> TestCountries { get; set; }

        public virtual ICollection<CountryTest> CountryTests { get; set; }


    }
}
