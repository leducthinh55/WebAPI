using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class ProductVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public string PictureUrl { get; set; }
    }

    public class ProductCM
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetail { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public string PictureUrl { get; set; }

        public int Quantity { get; set; }

        [Required]
        public String ProductTypeName { get; set; }

        [Required]
        public String TypeGroupName { get; set; }

        [Required]
        public String TypeGroupUserName { get; set; }

        public IEnumerable<ProductDetailCM> ProductDetailCMs { get; set; }
    }

    public class ProductUM
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetail { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public string PictureUrl { get; set; }

        public int Quantity { get; set; }

        [Required]
        public String ProductTypeName { get; set; }

        [Required]
        public String TypeGroupName { get; set; }

        [Required]
        public String TypeGroupUserName { get; set; }

        public IEnumerable<ProductDetailUM> ProductDetailUMs { get; set; }
    }

    public class ProductIncludeDetailVM
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DescriptionDetail { get; set; }

        public decimal Price { get; set; }

        public decimal PromotionPrice { get; set; }

        public string PictureUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public int Quantity { get; set; }

        public decimal Vote { get; set; }

        public String ProductType { get; set; }

        public ICollection<ProductDetailVM> ProductDetailVMs { get; set; }
    }
}
