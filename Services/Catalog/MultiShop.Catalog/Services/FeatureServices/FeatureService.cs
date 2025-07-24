using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Feature> _featureCollection;

        public FeatureService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }


        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var entity = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(entity);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(c => c.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var entities = await _featureCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultFeatureDto>>(entities));
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var entity = await _featureCollection.Find<Feature>(c => c.FeatureId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdFeatureDto>(entity));
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var entity = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == entity.FeatureId, entity);
        }

    }
}
