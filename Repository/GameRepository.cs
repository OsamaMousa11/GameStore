﻿using GameStore;
using Microsoft.EntityFrameworkCore;
using RepositoryContract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

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
            Console.WriteLine($"Total games found: {games.Count()}");  
            return games;
        }

        public async Task<Game?> GameDetails(int id)
        {
            var games = await _context.Games.Include(g => g.Category).Include(g => g.Devices).ThenInclude(d => d.Device).AsNoTracking().SingleOrDefaultAsync(g=>g.Id==id);
            return games;
        }

    

        public async Task<Game?> FindGame(EditGameFormViewModel model)
        {
           return  await _context.Games.Include(g=>g.Devices).SingleOrDefaultAsync(g=>g.Id==model.Id);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Game?> GetByid(int id)
        {
            return await _context.Games.FindAsync(id);
        }

      

        public void Remove(Game game)
        {
            _context.Games.Remove(game);
        }
    }
}
