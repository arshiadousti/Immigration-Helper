using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CountryTest
    {
        [Key]
        public int Id { get; set; }

        public int TestId { get; set; }

        public int CountryId { get; set; }


        //Navigation

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
