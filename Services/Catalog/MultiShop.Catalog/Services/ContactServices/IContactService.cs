﻿using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(string id);
    }
}
