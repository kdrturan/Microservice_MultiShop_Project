using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageImageServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageSerivce
    {
        private readonly IMongoCollection<ProductImage> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var entity = _mapper.Map<ProductImage>(createProductImageDto);
            await _categoryCollection.InsertOneAsync(entity);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c => c.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var value = await _categoryCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultProductImageDto>>(value));
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _categoryCollection.Find<ProductImage>(c => c.ProductImageId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdProductImageDto>(value));
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var entity = _mapper.Map<ProductImage>(updateProductImageDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.ProductImageId == entity.ProductImageId, entity);
        }
    }
}
