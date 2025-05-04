using DataRepository.Interfaces;
using Microsoft.Extensions.Logging;
using Model;

namespace BusinessAccessLayer
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repo, ILogger<ProductService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Product product)
        {
            _logger.LogInformation("Processing product...");
            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(int id, Product product)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new Exception("Product not found");

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.StockAvailable = product.StockAvailable;

            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<bool> AddToStock(int id, int quantity)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            product.StockAvailable += quantity;
            await _repo.UpdateAsync(product);
            return true;
        }

        public async Task<bool> DecrementStock(int id, int quantity)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null || product.StockAvailable < quantity) return false;

            product.StockAvailable -= quantity;
            await _repo.UpdateAsync(product);
            return true;
        }

    }
}