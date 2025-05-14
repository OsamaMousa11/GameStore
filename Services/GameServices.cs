using GameStore;
using GameStore.Settings;
using GameStore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class GameServices : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagespath;
        public GameServices(IGameRepository gameRepository, IWebHostEnvironment webHostEnvironment)
        {
            _gameRepository = gameRepository;
            _webHostEnvironment = webHostEnvironment;
            _imagespath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }
        public async Task Create(CreateGameFormViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_imagespath, coverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();

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
    }
}
