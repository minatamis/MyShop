using MyShop.Domain.Entities;
using MyShop.Application.Interfaces.IServices;
using MyShop.Application.Interfaces.IRepositories;
using Microsoft.Extensions.Logging;

namespace MyShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<List<Product>> GetProductList()
        {
            try
            {
                _logger.LogInformation("Products fetching from service");
                return await _productRepository.GetProductList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product list");
                return null;
            }
        }
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                _logger.LogInformation($"Product {id} fetching from service");
                return await _productRepository.GetProduct(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product");
                return null;
            }
        }
        public async Task AddProduct(Product product)
        {
            try
            {
                if(product != null)
                {
                    _logger.LogInformation($"Creating product {product.ProductId}");
                    await _productRepository.AddProduct(product);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error creating product product");
                throw;
            }
        }
        public async Task EditProduct(Product product)
        {
            try
            {
                if (product != null)
                {
                    _logger.LogInformation($"Updating product {product.ProductId}");
                    await _productRepository.EditProduct(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                throw;
            }
        }
        public async Task DeleteProduct(int id)
        {

            try
            {
                var product = await _productRepository.GetProduct(id);
                if (product != null)
                {
                    _logger.LogInformation($"Deleting product {product.ProductId}");
                    await _productRepository.DeleteProduct(product);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                throw;
            }
        }
    }
}
