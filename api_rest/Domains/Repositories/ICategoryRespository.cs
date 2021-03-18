using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domains.Models;

namespace api_rest.Domains.Repositories
{
    public interface ICategoryRespository
    {
        Task<IEnumerable<Category>> ListAsync();

        Task AddAsync(Category category);

        Task<Category> FindByIdAsync(int id);

        void Update(Category category);
    }
}