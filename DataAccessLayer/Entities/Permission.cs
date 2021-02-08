using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "سطح دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Name { get; set; }


        //Navigation 
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
