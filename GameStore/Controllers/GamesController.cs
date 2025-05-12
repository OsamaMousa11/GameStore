
using ServicesContract;

namespace GameStore.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGameService _gameServices;

        public GamesController(ICategoriesService categoriesService,IDevicesService devicesService, IGameService gameServices)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gameServices = gameServices;
        }

        public async Task<IActionResult> Index()
        {
            var games =await _gameServices.GetAllGames();
            return View(games);
        }
        
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
        public async Task <IActionResult> Create(CreateGameFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetListCategories();
                model.Devices = _devicesService.GetListDevices();
                return View(model);
            }
            await _gameServices.Create(model);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
