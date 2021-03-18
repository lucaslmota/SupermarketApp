using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Repositories;
using api_rest.Domains.Services;
using api_rest.Domains.Services.Communication;

namespace api_rest.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;
        private readonly IUnityOfWork _unityOfWork;

        public CategoryService(ICategoryRespository categoryRepository, IUnityOfWork unityOfWork)
        {
            _categoryRepository = categoryRepository;
            _unityOfWork = unityOfWork;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }  

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unityOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }

            catch(Exception ex)
            {
                return new SaveCategoryResponse($"Um erro ocorreu quando salvado a categoria: {ex.Message}");
            }
        }
    
        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new SaveCategoryResponse("Categoria não encontrada");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unityOfWork.CompleteAsync();

                return new SaveCategoryResponse(existingCategory);
            }

            catch (Exception ex)
            {
                return new SaveCategoryResponse($"Um erro aconteceu ao carregar a categoria: {ex.Message}");
            }
        }
    }
}