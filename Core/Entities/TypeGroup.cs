using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class TypeGroup // Feature , Shoe, Clothing,..
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Name { get; set; }

        public virtual ICollection<ProductType> ProductTypes { get; set; }

        public int TypeGroupUserId { get; set; }

        public virtual TypeGroupUser TypeGroupUser { get; set; }
    }
}
