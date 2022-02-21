using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    public  class ShopDbContext:DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new SettingConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
