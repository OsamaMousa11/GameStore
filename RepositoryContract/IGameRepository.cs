using GameStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace RepositoryContract
{
    public interface IGameRepository
    {
        Task AddGame(Game game);
        Task<IEnumerable<Game>> GetGames();
        Task <Game?>GameDetails(int id);

        Task<Game?> FindGame(EditGameFormViewModel model);

        Task<IEnumerable> Save();
    }
}
