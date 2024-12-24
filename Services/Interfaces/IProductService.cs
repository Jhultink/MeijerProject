using MeijerProject.Models;

namespace MeijerProject.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
        Task<ProductDetail?> GetProductDetailsAsync(int id);
    }
}
