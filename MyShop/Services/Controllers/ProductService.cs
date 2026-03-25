using MyShop.Models.Base;
using MyShop.Services.Interface;

namespace MyShop.Services.Controllers
{
    public class ProductService : IProductService
    {
        private readonly IStorageService _storageService;
        public ProductService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public Task<Dictionary<string, object>> GetProductList()
        {
            var productList = new List<Product>();
            var result  =  new Dictionary<string , object>();
            try
            {
                productList = _storageService.ProductStorage();
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["ProductList"] = productList
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            return Task.FromResult(result);
        }
        public Task<Dictionary<string, object>> GetProductById(int id)
        {
            var product = new Product();
            var result = new Dictionary<string, object>();
            try
            {
                product = _storageService.ProductStorage().FirstOrDefault(o => o.ProductId == id);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "success",
                    ["Product"] = product
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            return Task.FromResult(result);
        }
        public async Task AddProduct(Product product)
        {
            var result = new Dictionary<string, object>();
            try
            {
                _storageService.ProductStorage().Add(product);
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "product added"
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            
            await Task.FromResult(result);
        }
        public async Task EditProduct(Product product)
        {
            var result = new Dictionary<string, object>();
            try
            {
                var editProd = _storageService.ProductStorage().FirstOrDefault(o => o.ProductId == product.ProductId);
                if (editProd != null)
                {
                    editProd.ProductId = product.ProductId;
                    editProd.ProductName = product.ProductName;
                    editProd.ProductPrice = product.ProductPrice;
                }
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "product edited"
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            await Task.FromResult(result);
        }
        public async Task DeleteProduct(int id)
        {
            
            var result = new Dictionary<string, object>();
            try
            {
                Product product = _storageService.ProductStorage().FirstOrDefault(o => o.ProductId == id);
                if (product != null)
                {
                    _storageService.ProductStorage().Remove(product);
                }
                result = new()
                {
                    ["httpCode"] = 200,
                    ["message"] = "product deleted",
                };
            }
            catch (Exception ex)
            {
                result = new()
                {
                    ["httpCode"] = 400,
                    ["message"] = ex
                };
            }
            await Task.FromResult(result);
        }
    }
}
