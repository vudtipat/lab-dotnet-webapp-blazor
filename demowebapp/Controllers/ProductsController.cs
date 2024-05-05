using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demowebapp.Models;
using demowebapp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demowebapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private JsonFileProductService _productService;

        public ProductsController(JsonFileProductService jsonFileProduct)
        {
            _productService = jsonFileProduct;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet("Rate")]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            _productService.AddRating(productId,rating);
            return Ok();
        }
    }
}

