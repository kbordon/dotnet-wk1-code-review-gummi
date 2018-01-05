﻿using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
    public class GummiBearKingdomDbContext : DbContext
    {
        public GummiBearKingdomDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibearkingdom;uid=root;pwd=root;");
        }

        public GummiBearKingdomDbContext(DbContextOptions<GummiBearKingdomDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}