using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class LangCountry
    {
        [Key]
        public int Id { get; set; }

        public int LangId { get; set; }

        public int CountryId { get; set; }


        //Navigation
        [ForeignKey("LangId")]
        public virtual Language Language { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
