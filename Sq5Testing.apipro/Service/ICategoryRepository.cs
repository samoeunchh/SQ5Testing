using Sq5Testing.apipro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sq5Testing.apipro.Service
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategory();
        public Task<Category> GetCategoryById(Guid id);
        public Task<bool> SaveCategory(Category category);
        public Task<bool> UpdateCategory(Category category,Guid id);
        public Task<bool> DeleteCategory(Guid id);
    }
}
