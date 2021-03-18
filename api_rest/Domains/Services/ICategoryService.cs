using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Services.Communication;

namespace api_rest.Domains.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<SaveCategoryResponse> SaveAsync(Category category);

        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);
    }
}