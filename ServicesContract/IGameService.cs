using GameStore;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContract
{  
    public interface IGameService
    {
       Task Create(CreateGameFormViewModel model);
        Task<IEnumerable<Game>> GetAllGames();
    }
}
