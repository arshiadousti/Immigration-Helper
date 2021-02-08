using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DegreeId { get; set; }

        public int SpentMoneyId { get; set; }

        public int LangId { get; set; }

        [Display(Name = "نمره آیلتس")]
        public int Ielts { get; set; }

        [Display(Name = "نیاز به ویزا")]
        public bool Visa { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        //Navigation
        [ForeignKey("DegreeId")]
        public virtual Degree Degree { get; set; }

        [ForeignKey("SpentMoneyId")]
        public virtual SpentMoney SpentMoney { get; set; }

        [ForeignKey("LangId")]
        public virtual Language Language { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<CountryTest> CountryTests { get; set; }


        //public virtual ICollection<TestCountry> TestCountries { get; set; }





    }
}
