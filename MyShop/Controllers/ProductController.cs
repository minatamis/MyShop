using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Entities;
using MyShop.Application.Interfaces.IServices;

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
        public async Task<ActionResult<Response<List<Product>>>> GetProductList()
        {
            var productList = await _productService.GetProductList();
            try
            {
                if (productList == null)
                    return NotFound(Response<List<Product>>.Fail);
                else
                    return Ok(Response<List<Product>>.Success(productList, "Products Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<List<Product>>.Fail);
            }
        }
        [HttpGet]
        [Route("get-product")]
        public async Task<ActionResult<Response<Product>>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            try
            {
                if (product == null)
                    return NotFound(Response<Product>.Fail);
                else
                    return Ok(Response<Product>.Success(product, "Product Found"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<Product>.Fail);
            }
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<ActionResult<Response<object>>> AddProduct(Product product)
        {
            try
            {
                await _productService.AddProduct(product);
                return Ok(Response<object>.Success(product,"Product added successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpPut]
        [Route("edit-product")]
        public async Task<ActionResult<Response<object>>> EditProduct(Product product)
        {
            try
            {
                await _productService.EditProduct(product);
                return Ok(Response<object>.Success(product, "Product edited successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
        [HttpDelete]
        [Route("delete-product")]
        public async Task<ActionResult<Response<object>>> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok(Response<object>.Success(id, "Product deleted successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(Response<object>.Fail);
            }
        }
    }
}
