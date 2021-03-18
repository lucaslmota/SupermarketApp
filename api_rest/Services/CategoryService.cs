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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unityOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }

            catch(Exception ex)
            {
                return new CategoryResponse($"Um erro ocorreu quando salvado a categoria: {ex.Message}");
            }
        }
    
        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse("Categoria não encontrada");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unityOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }

            catch (Exception ex)
            {
                return new CategoryResponse($"Um erro aconteceu ao carregar a categoria: {ex.Message}");
            }
        }
    
        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse("Categoria não encontrada");
            }

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unityOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Um erro ocorreu quando a categoria foi apagada: {ex.Message}");
            }
        }
    
    }
}