using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;

namespace SportsStoreApp.MVC.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product entity = context.Products.FirstOrDefault(m => m.ProductId == product.ProductId);
                if (entity != null)
                {
                    entity.Name = product.Name;
                    entity.Category = product.Category;
                    entity.Price = product.Price;
                    entity.Description = product.Description;
                }
            }
            context.SaveChanges();
        }
    }
}
