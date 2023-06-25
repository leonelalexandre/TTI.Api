using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTI.Domain.Entity;
using TTI.Domain.Interface;
using TTI.Infra.Data.Context;

namespace TTI.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly TTIContext _context;
        public ProductRepository(TTIContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await Task.Run(
                () => _context.Add(product)
            );
        }

        public async Task DeleteAsync(Product product)
        {
            await Task.Run(
                () => _context.Remove(product)
            );
        }

        public async Task EditAsync(Product product)
        {
            await Task.Run(
              () => _context.Entry(product).State = EntityState.Modified
            );
        }

        public async Task<IEnumerable<Product>> Filter()
        {
            return await _context.Products
                .Include(x => x.IdCategoriesNavigation)
                .Include(x => x.IdCategoriesNavigation.IdSubCategoryNavigation)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            Product product;

            return product = await _context.Products
                .Include(x=> x.IdCategoriesNavigation)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Product>> GetByKeyword(string keyword)
        {
            var param = new SqlParameter("@Keyword", keyword);
            return await _context.Products.FromSqlRaw("GetByProductsKeyword @Keyword", param).ToListAsync(); ;
        }
    }
}
