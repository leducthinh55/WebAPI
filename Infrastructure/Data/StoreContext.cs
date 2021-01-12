using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContext : IdentityDbContext<User>
    {
       
        public StoreContext() : base((new DbContextOptionsBuilder())
            .UseSqlServer("Server=.;Database=ECommerce;Trusted_Connection=True;MultipleActiveResultSets= true")
            .EnableSensitiveDataLogging()
            .Options)
        {
        }


        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<ModifiedProduct> ModifiedProducts { get; set; }

        public DbSet<TypeGroup> TypeGroups { get; set; }

        public DbSet<TypeGroupUser> TypeGroupUsers { get; set; }

        public DbSet<Color> Colors { get; set; }

        public async Task<bool> Commit()
        {
            int result = await base.SaveChangesAsync();
            return result > 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Product>().Property(_ => _.Name).HasMaxLength(250).IsUnicode();
            builder.Entity<Product>().Property(_ => _.PictureUrl).HasMaxLength(250);
            builder.Entity<Product>().Property(_ => _.Price).IsRequired();
            builder.Entity<Product>().Property(_ => _.Quantity).IsRequired();

            builder.Entity<ProductType>().Property(_ => _.Name).HasMaxLength(250).IsRequired().IsUnicode();


            builder.Entity<ProductType>().Property(_ => _.TypeGroupId).HasDefaultValue(0);

            builder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId);

            builder.Entity<Product>()
                .HasOne(_ => _.User)
                .WithMany(_ => _.Products)
                .HasForeignKey(_ => _.CreateBy);

            builder.Entity<ModifiedProduct>()
                .HasOne(_ => _.User)
                .WithMany(_ => _.ModifiedProducts)
                .HasForeignKey(_ => _.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(_ => _.ModifiedProducts)
                .WithOne(_ => _.Product)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Product>()
                .HasMany(_ => _.ProductDetails)
                .WithOne(_ => _.Product)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductType>()
                .HasOne(_ => _.TypeGroup)
                .WithMany(_ => _.ProductTypes)
                .HasForeignKey(_ => _.TypeGroupId);

            builder.Entity<TypeGroup>()
                .HasOne(_ => _.TypeGroupUser)
                .WithMany(_ => _.TypeGroups)
                .HasForeignKey(_ => _.TypeGroupUserId);
            base.OnModelCreating(builder);
        }
    }
}
