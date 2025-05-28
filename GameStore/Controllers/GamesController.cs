
using Microsoft.AspNetCore.Mvc;
using ServicesContract;
using System.Threading.Tasks;
using ViewModels;

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

        public async Task <IActionResult> Details(int id)
        {  

            var game= await _gameServices.GetById(id);
            if(game is null)
                return NotFound();  
            return View(game);
        }

        [HttpGet ]
        public async Task<IActionResult>Edit(int id )
        {
            var game = await  _gameServices.GetEditGameViewModelAsync(id);
            if (game is null)
                return NotFound();
            return View(game);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories =_categoriesService.GetListCategories();
                model.Devices =_devicesService.GetListDevices();
                return View(model);
            }

            var game = await _gameServices.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete("Game/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted =await  _gameServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }



    }
}
