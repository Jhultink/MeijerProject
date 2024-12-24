using MeijerProject.Models.Dtos;

namespace MeijerProject.Services.Interfaces
{
    interface IProductService
    {
        Task<IEnumerable<ProductDto>?> GetProductsAsync();
        Task<ProductDetailDto?> GetProductDetailsAsync(int id);
    }
}
