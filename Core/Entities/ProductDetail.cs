using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class ProductDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String ImangeUrl {get;set;}

        public Color Color { get; set; } 

        [ForeignKey("Colors")]
        public int ColorId { get; set; } 

        public Product Product { get; set; } 

        public Guid ProductId { get; set; }
    }
}
