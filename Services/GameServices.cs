using GameStore;
using GameStore.Settings;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryContract;
using ServicesContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Services
{
    public class GameServices : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagespath;
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;    
        public GameServices(IGameRepository gameRepository, IWebHostEnvironment webHostEnvironment , ICategoriesService categoriesService, IDevicesService devicesService)
        {
            _gameRepository = gameRepository;
            _webHostEnvironment = webHostEnvironment;
            _imagespath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
            _categoriesService = categoriesService;
            _devicesService = devicesService;
        }
        public async Task Create(CreateGameFormViewModel model)
        {
            
            var coverName = await SaveCover(model.Cover);   

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList(),
            };
            await _gameRepository.AddGame(game);

        }

        public  async Task<IEnumerable<Game>> GetAllGames()
        {
            var games = await _gameRepository.GetGames();
            Console.WriteLine($"Fetched {games.Count()} games from the repository.");
            return games;

        }

       
         public async Task<Game> GetById(int id)
        {
            var game = await _gameRepository.GameDetails(id);
            return game;    
        }

        public async Task<EditGameFormViewModel> GetEditGameViewModelAsync(int id)
        {
            var game= await _gameRepository.GameDetails(id);
            if (game == null)
                return null;
            return new EditGameFormViewModel
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesService.GetListCategories(),
                Devices = _devicesService.GetListDevices(),
                CurrentCover = game.Cover
            };
        }

    /*    [HttpDelete]
        public IActionResult Delete(int id)
        {
            var game = _gameRepository.GameDetails(id);
            if (game == null)
            {
                return NotFound();
            }
            var path = Path.Combine(_imagespath, game.Cover);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _gameRepository.DeleteGame(game);
            return Ok();
        }*/

        public async Task<Game?> Update(EditGameFormViewModel model)
        {
            var game = await _gameRepository.FindGame(model);
            if(game == null)
                return null;
            var hasNewCover = model.Cover is not null;
            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            if(hasNewCover)
            {
                game.Cover=await SaveCover(model.Cover!);
            }
             var  eff=await _gameRepository.Save();
        }
        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagespath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            return coverName;
        }

        /*   bool IGameService.Delete(int id)
           {
               throw new NotImplementedException();
           }*/
    }
}
