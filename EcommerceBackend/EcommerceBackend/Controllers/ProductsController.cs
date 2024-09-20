using EcommerceBackend.Core.Models;
using EcommerceBackend.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string category, string searchTerm = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                Console.WriteLine("logged");
            }

            IEnumerable<Product> products;
            if (category == "All")
            {
                products = _unitOfWork.Products.GetAll();
                return Ok(products);
            }
            products = _unitOfWork.Products.FindAll(p => p.Category.Name == category);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _unitOfWork.Products.GetById(id);

            return Ok(product);
        }
    }
}
