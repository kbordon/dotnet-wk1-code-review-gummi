using Microsoft.EntityFrameworkCore;
               
namespace GummiBearKingdom.Models
{
    public class TestDbContext : GummiBearKingdomDbContext
    {
        public override DbSet<Product> Products { get; set; }
        public override DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibearkingdom_test;uid=root;pwd=root;");
        }
    }
}
