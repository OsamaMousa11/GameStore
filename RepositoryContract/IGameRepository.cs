using GameStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContract
{
    public interface IGameRepository
    {
        Task AddGame(Game game);
        Task<IEnumerable<Game>> GetGames();
    }
}
