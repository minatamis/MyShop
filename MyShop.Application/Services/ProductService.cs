using MyShop.Domain.Entities;
using MyShop.Application.Interfaces.IServices;
using MyShop.Application.Interfaces.IRepositories;

namespace MyShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductList()
        {
            try
            {
                return await _productRepository.GetProductList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetProduct(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task AddProduct(Product product)
        {
            try
            {
                if(product != null)
                    await _productRepository.AddProduct(product);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task EditProduct(Product product)
        {
            try
            {
                if (product != null)
                    await _productRepository.EditProduct(product);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteProduct(int id)
        {

            try
            {
                var product = await _productRepository.GetProduct(id);
                if (product != null)
                    await _productRepository.DeleteProduct(product);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
