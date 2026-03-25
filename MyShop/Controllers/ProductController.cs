using Microsoft.AspNetCore.Mvc;
using MyShop.Models.Base;
using MyShop.Services.Controllers;
using MyShop.Services.Interface;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("my-shop/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("get-product-list")]
        public async Task<IActionResult> GetProductList()
        {
            var productList = await _productService.GetProductList();
            return Ok(productList);
        }
        [HttpGet]
        [Route("get-product")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            return Ok();
        }
        [HttpPut]
        [Route("edit-product")]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _productService.EditProduct(product);
            return Ok();
        }
        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
