using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class User :IdentityUser,IAuditableEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Email { get; set; }
        public string IdentityNo { get; set; }
        public char Sex { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }
}
