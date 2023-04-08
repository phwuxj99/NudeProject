using NudeProject.Models;

namespace NudeProject.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        List<Product> CreateProduct(Product product);
        List<Product> DeleteProduct(int id);
    }
}
