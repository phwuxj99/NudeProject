using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NudeProject;
using NudeProject.Models;
using NudeProject.Repositories;
using System.Reflection;

namespace NudeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly NudeDBContext nudeDBContext;
        private readonly IProductRepository productRepository;

        private Product product { get; set; }
        private IList<Product> products { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NudeDBContext nudeDBContext, IProductRepository productRepository)
        {
            _logger = logger;
            this.nudeDBContext = nudeDBContext;
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            products = productRepository.GetAllProduct();
            return products;
        }
       

        [HttpPost]
        public IEnumerable<Product> Create(Product product)
        {
            products = productRepository.CreateProduct(product);

            return products;
        }


        [HttpDelete]
        [Route("Delete/{id?}")]
        public IEnumerable<Product> DeleteConfirmed(int id)
        {
            products = productRepository.DeleteProduct(id);

            return products;
        }
    }
}