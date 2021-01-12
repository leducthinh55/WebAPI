using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class TypeGroupUserVM
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<TypeGroupVM> TypeGroups { get; set; }
    }
}
