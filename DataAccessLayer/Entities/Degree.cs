using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Degree
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "مقطع مورد نظر")]
        [MaxLength(20)]
        public string Name { get; set; }

        //Navigation


        public virtual ICollection<DegreeCountry> DegreeTests { get; set; }


    }
}
