
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using RepositoryContract;


namespace Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoryRepository _db;
        public CategoriesService(ICategoryRepository db)
        {
            _db= db;
        }
        public IEnumerable<SelectListItem> GetListCategories()
        {
            return _db.GetListCategory();
        }

        
    }
}
