using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
        }
        public async Task<long> GetBrandCount()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var product = await _productCollection
                .Find(Builders<Product>.Filter.Empty)
                .SortByDescending(p => p.ProductPrice)
                .Project(p => p.ProductName)
                .FirstOrDefaultAsync();

            return product ?? string.Empty;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var sort = Builders<Product>.Sort.Ascending(p => p.ProductPrice);

            var product = await _productCollection
                .Find(Builders<Product>.Filter.Empty)
                .Sort(sort)
                .Project(p => p.ProductName)
                .FirstOrDefaultAsync();

            return product ?? string.Empty;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var values = await _productCollection
                .Aggregate()
                .Group(x => 1, g => new { AvgPrice = g.Average(x => x.ProductPrice) })
                .FirstOrDefaultAsync();
            return values?.AvgPrice ?? 0;
        }

        public async Task<long> GetProductCount()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);

        }
    }
}
