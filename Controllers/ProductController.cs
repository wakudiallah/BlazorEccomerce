using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: /<controller>/
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProduct()
        {
            var r = await _productService.GetProduct();
            return Ok(r);
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<ActionResult<ServiceResponse<ProductDetailsVM>>> GetProduct(int Id)
        {
            var r = await _productService.GetProduct(Id);
            return Ok(r);
        }
    }
}

