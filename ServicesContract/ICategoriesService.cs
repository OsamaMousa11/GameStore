
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServicesContract
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetListCategories();
    }
}
