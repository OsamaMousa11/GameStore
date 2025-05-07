using GameStore;
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

        public  async Task AddGame(Games game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
    }
}
