using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var entity = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(entity);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(c => c.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var value = await _contactCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultContactDto>>(value));
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _contactCollection.Find<Contact>(c => c.ContactId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdContactDto>(value));
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var entity = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == entity.ContactId, entity);
        }
    }
}
