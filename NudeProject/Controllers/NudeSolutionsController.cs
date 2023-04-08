using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NudeProject;
using NudeProject.Models;
using Project1.Controllers;

namespace NudeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NudeSolutionsController :  ControllerBase
    {
        private readonly ILogger<NudeSolutionsController> _logger;
        private readonly NudeDBContext nudeDBContext;

        public Product product { get; set; }
        public IList<Product> products { get; set; }

        public NudeSolutionsController(ILogger<NudeSolutionsController> logger, NudeDBContext nudeDBContext)
        {
            _logger = logger;
            this.nudeDBContext = nudeDBContext;
        }


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
