using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class TypeGroupUser
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<TypeGroup> TypeGroups { get; set; }
    }
}
