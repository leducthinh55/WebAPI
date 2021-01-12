using System;
using System.Collections.Generic;

namespace WebAPI.ViewModels
{
    public class TypeGroupVM
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public virtual ICollection<ProductTypeVM> ProductTypes { get; set; }
    }
}