using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "زبان مورد نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(30)]
        public string Name { get; set; }

        //Navigation

        public virtual ICollection<LangCountry> LangCountries { get; set; }

    }
}
