using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IProductService
    {
        Task<Dictionary<string, object>> GetProductList();
        Task<Dictionary<string, object>> GetProductById(int id);
        Task AddProduct(Product product);
        Task EditProduct(Product product);
        Task DeleteProduct(int id);
    }
}
