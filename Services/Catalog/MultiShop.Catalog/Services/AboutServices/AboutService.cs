using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<About> _aboutCollection;

        public AboutService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }


        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var entity = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(c => c.AboutId == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var entities = await _aboutCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultAboutDto>>(entities));
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            var entity = await _aboutCollection.Find<About>(c => c.AboutId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdAboutDto>(entity));
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var entity = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.FindOneAndReplaceAsync(x => x.AboutId == entity.AboutId, entity);
        }

    }
}
