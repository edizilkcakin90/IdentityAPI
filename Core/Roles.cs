using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Roles : IdentityRole
    {
        public Roles()
        {

        }

        public Roles(string roleName) : base(roleName)
        {

        }

        public Roles(string roleName, string description) : base(roleName)
        {
            Description = description;
        }

        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
