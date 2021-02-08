using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class DegreeCountry
    {
        [Key]
        public int Id { get; set; }

        public int DegreeId { get; set; }

        public int CountryId { get; set; }


        //Navigation

        [ForeignKey("DegreeId")]
        public virtual Degree Degree { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
