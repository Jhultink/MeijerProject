using MeijerProject.Models;
using MeijerProject.Services.Interfaces;
using Newtonsoft.Json;

namespace MeijerProject.Services
{
    internal class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDetail?> GetProductDetailsAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"/product-details/{id}.json");
            return response == null ? null : JsonConvert.DeserializeObject<ProductDetail>(response);
        }

        public async Task<IEnumerable<Product>?> GetProductsAsync()
        {
            var response = await _httpClient.GetStringAsync("/products.json");
            return response == null ? null : JsonConvert.DeserializeObject<IEnumerable<Product>>(response);
        }
    }
}
