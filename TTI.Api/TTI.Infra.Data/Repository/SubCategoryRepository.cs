using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using TTI.Infra.Data.Context;

namespace TTI.Infra.Data.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly TTIContext _context;
        public SubCategoryRepository(TTIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SubCategory subCategory)
        {
            await Task.Run(
                () => _context.Add(subCategory)
            );
        }

        public async Task DeleteAsync(SubCategory subCategory)
        {
            await Task.Run(
                () => _context.Remove(subCategory)
            );
        }

        public async Task EditAsync(SubCategory subCategory)
        {
            await Task.Run(
              () => _context.Entry(subCategory).State = EntityState.Modified
            );
        }

        public async Task<IEnumerable<SubCategory>> Filter()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public async Task<SubCategory> GetById(int id)
        {
            SubCategory subCategory;

            return subCategory = await _context.SubCategories.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
