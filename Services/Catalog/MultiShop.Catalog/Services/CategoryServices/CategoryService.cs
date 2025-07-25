﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var entity = _mapper.Map<Category>(createCategoryDto);
           await _categoryCollection.InsertOneAsync(entity);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c => c.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var value = await  _categoryCollection.Find(c => true).ToListAsync();
            return (_mapper.Map<List<ResultCategoryDto>>(value));
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(c => c.CategoryId == id).FirstOrDefaultAsync();
            return (_mapper.Map<GetByIdCategoryDto>(value));
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var entity = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == entity.CategoryId, entity);
        }
    }
}
