using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using TTI.Infra.Data.Context;

namespace TTI.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TTIContext _context;
        public CategoryRepository(TTIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            await Task.Run(
                () => _context.Add(category)
            );
        }

        public async Task DeleteAsync(Category category)
        {
            await Task.Run(
                () => _context.Remove(category)
            );
        }

        public async Task EditAsync(Category category)
        {
            await Task.Run(
              () => _context.Entry(category).State = EntityState.Modified
            );
        }

        public async Task<IEnumerable<Category>> Filter()
        {
            return await _context.Categories.Include(x => x.IdSubCategoryNavigation).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            Category category;

            return category = await _context.Categories.Include(x => x.IdSubCategoryNavigation).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
