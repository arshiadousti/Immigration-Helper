using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public string ActiveCode { get; set; }

        public  DateTime RegisterDate { get; set; }

        //Navigation
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        //public virtual Test Test { get; set; }


        public virtual ICollection<Test> Tests { get; set; }
    }
}
