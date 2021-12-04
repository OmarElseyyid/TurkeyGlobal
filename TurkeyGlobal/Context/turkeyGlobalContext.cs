using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entity.Entity;

namespace TurkeyGlobal.Context
{
    public class turkeyGlobalContext : DbContext
    {
       
            public turkeyGlobalContext()
                : base("name=GlobalTurkeyContext")
            {
            }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            }
            public DbSet<BuyerInfo> BuyerInfos { get; set; }
            public DbSet<CurrencyType> CurrencyTypes { get; set; }
            public DbSet<Massages> Massages { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<ProductCategory> ProductCategories { get; set; }
            public DbSet<ProductFile> ProductFiles { get; set; }
            public DbSet<SellerInfo> SellerInfos { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserRol> UserRols { get; set; }
    }
}
