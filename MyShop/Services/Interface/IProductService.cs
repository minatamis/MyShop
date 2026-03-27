using MyShop.Models.Base;

namespace MyShop.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task EditProduct(Product product);
        Task DeleteProduct(int id);
    }
}
