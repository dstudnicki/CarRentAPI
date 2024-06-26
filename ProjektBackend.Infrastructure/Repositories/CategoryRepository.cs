using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }
    }
}
