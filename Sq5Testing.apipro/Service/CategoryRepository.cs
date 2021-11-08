using Sq5Testing.apipro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sq5Testing.apipro.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteCategory(Guid id)
        {
            try
            {
                var category = await _context.Category.
                    FirstOrDefaultAsync(x => x.CategoryId.Equals(id));
                if (category == null)
                {
                    return false;
                }
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategory()
            => await _context.Category.ToListAsync();

        public async Task<Category> GetCategoryById(Guid id)
            => await _context.Category.FirstOrDefaultAsync(x => x.CategoryId.Equals(id));

        public async Task<bool> SaveCategory(Category category)
        {
            try
            {
                _context.Category.Add(category);
               await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategory(Category category, Guid id)
        {
            try
            {
                var cate =await _context.Category.FirstOrDefaultAsync(x => x.CategoryId.Equals(id));
                if (cate == null) 
                    return false;
                _context.Category.Attach(cate);
                cate.CategoryName = category.CategoryName;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
