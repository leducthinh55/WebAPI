using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{

    public class ProductType // New Realse, SNKRS Launch Calender
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }

        public int TypeGroupId { get; set; }

        public virtual TypeGroup TypeGroup { get; set; }
    }
}