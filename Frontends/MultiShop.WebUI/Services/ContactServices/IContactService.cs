using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<UpdateContactDto> GetByIdContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(string id);
    }
}
