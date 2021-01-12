using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser
    {
        public String FullName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ModifiedProduct> ModifiedProducts { get; set; }
    }
}
