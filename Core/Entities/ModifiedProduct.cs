using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class ModifiedProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime ModifyDate { get; set; }

        public decimal OldPrice { get; set; }

        public decimal NewPrice { get; set; }

        public decimal OldQuantity { get; set; }

        public decimal NewQuantity { get; set; }

        public int Status { get; set; } // 1: Create, 2 : Updated

        public Product Product {get;set;}

        public Guid ProductId { get; set; }

        public virtual User User { get; set; }

        public String ModifiedBy { get; set; }
    }
}
