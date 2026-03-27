using Microsoft.AspNetCore.Http.HttpResults;
using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IStorageService _storageService;
        public ProductService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<List<Product>> GetProductList()
        {
            List<Product> productList = new();
            try
            {
                productList = _storageService.GetProductList();
            }
            catch (Exception ex)
            {
                return null;
            }
            return productList;
        }
        public async Task<Product> GetProductById(int id)
        {
            Product product;
            try
            {
                product = _storageService.GetProduct(id);
            }
            catch (Exception ex)
            {
                return null;
            }
            return product;
        }
        public Task AddProduct(Product product)
        {
            try
            {
                if(product != null)
                    _storageService.AddProduct(product);
            }
            catch(Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task EditProduct(Product product)
        {
            try
            {
                if (product != null)
                    _storageService.EditProduct(product);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
        public Task DeleteProduct(int id)
        {

            try
            {
                if (id != null)
                    _storageService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

            return Task.CompletedTask;
        }
    }
}
