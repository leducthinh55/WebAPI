using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetail { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public int Quantity { get; set; }

        public decimal Vote { get; set; } //  top sản phẩm xịn xò

        public String CreateBy { get; set; }

        public virtual User User { get; set; }

        public virtual ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public virtual ICollection<ModifiedProduct> ModifiedProducts { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
