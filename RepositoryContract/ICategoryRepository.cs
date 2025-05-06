using Microsoft.AspNetCore.Mvc.Rendering;

namespace RepositoryContract
{
    public interface ICategoryRepository
    {
        List<SelectListItem> GetListCategory();
    }
}
