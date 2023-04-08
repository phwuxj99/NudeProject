using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NudeProject;
using NudeProject.Models;
using System.Reflection;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly NudeDBContext nudeDBContext;

        public Product product { get; set; }
        public IList<Product> products { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NudeDBContext nudeDBContext)
        {
            _logger = logger;
            this.nudeDBContext = nudeDBContext;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            products = nudeDBContext.Products.ToList();
            return products;
            //return Enumerable.Range(1, 15).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpGet("int/{id}")]
        public IEnumerable<Product> GetDetails(int id)
        {
            return Enumerable.Range(1, 7).Select(index => new Product
            {
                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IEnumerable<Product> Create(Product product)
        {
            //product = new Product { CategoryName = "Clothing", ItemName = "test", Price = 15 };

            nudeDBContext.Products.Add(product);
            nudeDBContext.SaveChanges();
            products = nudeDBContext.Products.ToList();

            return products;

            //return Enumerable.Range(1, 5).Select(index => new Product
            //{
            //    //Date = DateTime.Now.AddDays(index),
            //    //TemperatureC = Random.Shared.Next(-20, 55),
            //    //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        //[HttpPost]
        //public async Task<ActionResult<WeatherForecast>> CreateEmployee(WeatherForecast weatherForecast)
        //{
        //    //try
        //    //{
        //    //    if (employee == null)
        //    //        return BadRequest();

        //    //    var createdEmployee = await employeeRepository.AddEmployee(employee);

        //    //    return CreatedAtAction(nameof(GetEmployee),
        //    //        new { id = createdEmployee.EmployeeId }, createdEmployee);
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return StatusCode(StatusCodes.Status500InternalServerError,
        //    //        "Error creating new employee record");
        //    //}
        //    return null;
        //}



        // POST: Students/Delete/5
        [HttpPost]
        [Route("Delete/{id?}")]
        public IEnumerable<Product> DeleteConfirmed(int id)
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