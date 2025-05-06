
namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;

        public GamesController(ICategoriesService categoriesService,IDevicesService devicesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            CreateGameFormViewModel ViewModel = new()
            {
                Categories = _categoriesService.GetListCategories(),
                Devices = _devicesService.GetListDevices(),
            }; 
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetListCategories();
                model.Devices = _devicesService.GetListDevices();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
            
        }
    }
}
