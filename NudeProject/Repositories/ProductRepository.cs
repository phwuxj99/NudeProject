using Microsoft.EntityFrameworkCore;
using NudeProject.Controllers;
using NudeProject.Models;

namespace NudeProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NudeDBContext nudeDBContext;

        private Product product { get; set; }
        private List<Product> products { get; set; }

        public ProductRepository(NudeDBContext nudeDBContext)
        {
            this.nudeDBContext = nudeDBContext;
        }


        public List<Product> GetAllProduct()
        {
            products = nudeDBContext.Products.ToList();
            return products;
        }

        public List<Product> CreateProduct(Product product)
        {
            try
            {
                nudeDBContext.Products.Add(product);
                nudeDBContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
            }
            products = nudeDBContext.Products.ToList();

            return products;
        }

        public List<Product> DeleteProduct(int id)
        {
            try
            {
                Product productToDelete = new Product() { Id = id };
                nudeDBContext.Entry(productToDelete).State = EntityState.Deleted;
                nudeDBContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
            }

            products = nudeDBContext.Products.ToList();
            return products;
        }
    }
}
