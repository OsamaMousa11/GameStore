using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;

        public HomeController(IGameService gameService)
        {
            _gameService=gameService;
        }
     
        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGames();
            Console.WriteLine($"Number of games fetched: {games.Count()}");

            if (games != null && games.Any())
            {
                Console.WriteLine("Games are available.");
            }
            else
            {
                Console.WriteLine("No games found.");
            }

            return View(games);
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
