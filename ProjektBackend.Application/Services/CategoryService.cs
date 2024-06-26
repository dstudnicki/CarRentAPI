using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektBackend.Core.Interfaces;
using ProjektBackend.Core.Entities;
using ProjektBackend.Infrastructure.Repositories;

namespace ProjektBackend.Application.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Categories GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryRepository.CategoryExists(categoryId);
        }
    }
}
