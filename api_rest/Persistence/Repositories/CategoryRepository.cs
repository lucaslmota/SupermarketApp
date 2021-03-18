using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest.Domains.Models;
using api_rest.Domains.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api_rest.Persistence.Repositories
{
    public class CategoryRepository :BaseRepository, ICategoryRespository
    {
        public CategoryRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Category>> ListAsync(){
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}