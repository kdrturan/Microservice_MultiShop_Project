using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        private readonly IMongoCollection<Product> _productCollection;

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var entity = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(entity);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(c => c.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var entities = await _productCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultProductDto>>(entities));
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var entity = await _productCollection.Find<Product>(c => c.ProductId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdProductDto>(entity));
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var entity = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == entity.ProductId, entity);
        }
    }
}
