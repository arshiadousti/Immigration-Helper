using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class SpentMoney
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="میزان شهریه")]
        public int Money { get; set; }


        //Navigation


    }



}
