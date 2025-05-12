using GameStore;
using Microsoft.EntityFrameworkCore;
using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{   

    public  class GameRepository: IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public  async Task AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>>GetGames()
        {
            var games = await _context.Games.Include(g=>g.Category).Include(g=>g.Devices).ThenInclude(d=>d.Device).AsNoTracking().ToListAsync();
            Console.WriteLine($"Total games found: {games.Count()}");  // طباعة عدد الألعاب
            return games;
        }
    }
}
