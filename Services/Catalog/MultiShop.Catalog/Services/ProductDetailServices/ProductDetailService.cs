using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var entity = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _categoryCollection.InsertOneAsync(entity);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c => c.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var value = await _categoryCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultProductDetailDto>>(value));
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _categoryCollection.Find<ProductDetail>(c => c.ProductDetailId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdProductDetailDto>(value));
        }

        public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var value = await _categoryCollection.Find<ProductDetail>(c => c.ProductId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdProductDetailDto>(value));
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var entity = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == entity.ProductDetailId, entity);
        }
    }
}
