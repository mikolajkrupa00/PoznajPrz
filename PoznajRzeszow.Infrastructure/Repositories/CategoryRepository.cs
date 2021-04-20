using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using PoznajRzeszow.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PoznajRzeszowContext _context;

        public CategoryRepository(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(DbPlaceCategory.Create(category));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            var category = await (from c in _context.Categories
                                  where c.PlaceCategoryId == categoryId
                                  select c).FirstAsync();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetAsync(Guid categoryId)
            => await (from c in _context.Categories
                      where c.PlaceCategoryId == categoryId
                      select new Category(c.PlaceCategoryId, c.Name)).FirstAsync();

        public async Task UpdateAsync(Category category)
        {
            var _category = await (from c in _context.Categories
                                   where c.PlaceCategoryId == category.PlaceCategoryId
                                   select c).FirstAsync();
            _category.Name = category.Name;
            await _context.SaveChangesAsync();
        }
    }
}
