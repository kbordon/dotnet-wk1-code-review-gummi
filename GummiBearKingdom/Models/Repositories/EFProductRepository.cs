using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models.Repositories
{
    public class EFProductRepository
    {
        GummiBearKingdomDbContext db;

        public EFProductRepository()
        {
            db = new GummiBearKingdomDbContext();
        }

        // for testing purposes.
        public EFProductRepository(GummiBearKingdomDbContext thisDb)
        {
            db = thisDb;
        }

        // get all Products
        public IQueryable<Product> Products
        {
            get { return db.Products; }
        }

        // save product
        public Product Save(Product product)
        {
            db.Products.Add(boss);
            db.SaveChanges();
            return product;
        }

        // update a product
        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        // delete a product
        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        // delete all products
        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("delete from products");
        }
    }
}
