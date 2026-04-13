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
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        [Route("get-product-list")]
        public async Task<ActionResult<Response<List<Product>>>> GetProductList()
        {
            var productList = await _productService.GetProductList();
            try
            {
                if (productList == null)
                {
                    _logger.LogWarning("Products list is null");
                    return NotFound(Response<List<Product>>.Fail("Product not found"));
                }
                else
                {
                    _logger.LogInformation($"{productList.Count} Products Found");
                    return Ok(Response<List<Product>>.Success(productList, "Products Found"));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product list");
                return BadRequest(Response<List<Product>>.Fail(ex.ToString()));
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
                {
                    _logger.LogWarning($"Product {id} is null");
                    return NotFound(Response<Product>.Fail("Product not found"));
                }
                else
                {
                    _logger.LogInformation($"Product {id} is found");
                    return Ok(Response<Product>.Success(product, "Product Found")); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product");
                return BadRequest(Response<Product>.Fail(ex.ToString()));
            }
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<ActionResult<Response<object>>> AddProduct(Product product)
        {
            try
            {
                await _productService.AddProduct(product);
                _logger.LogInformation($"Product {product.ProductId} successfully created");
                return Ok(Response<object>.Success(product,"Product added successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpPut]
        [Route("edit-product")]
        public async Task<ActionResult<Response<object>>> EditProduct(Product product)
        {
            try
            {
                await _productService.EditProduct(product);
                _logger.LogInformation($"Product {product.ProductId} successfully updated");
                return Ok(Response<object>.Success(product, "Product edited successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
        [HttpDelete]
        [Route("delete-product")]
        public async Task<ActionResult<Response<object>>> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                _logger.LogInformation($"Product {id} successfully deleted");
                return Ok(Response<object>.Success(id, "Product deleted successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                return BadRequest(Response<object>.Fail(ex.ToString()));
            }
        }
    }
}
