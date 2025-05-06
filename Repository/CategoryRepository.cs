using GameStore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryContract;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetListCategory()
        {
            return _context.Categories
           .Select(x => new SelectListItem
            {
               Value = x.Id.ToString(),
               Text = x.Name
           }).ToList();
        }
    }
}
