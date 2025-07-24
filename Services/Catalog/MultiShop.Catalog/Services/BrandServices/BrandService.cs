using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Brand> _brandCollection;

        public BrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }


        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var entity = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(entity);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(c => c.BrandId == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var entities = await _brandCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultBrandDto>>(entities));
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var entity = await _brandCollection.Find<Brand>(c => c.BrandId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdBrandDto>(entity));
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var entity = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandId == entity.BrandId, entity);
        }

    }
}
