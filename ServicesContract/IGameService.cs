using GameStore;
using GameStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace ServicesContract
{  
    public interface IGameService
    {
       Task Create(CreateGameFormViewModel model);
        Task<IEnumerable<Game>> GetAllGames();
        Task  <Game?> GetById(int id);
        Task<EditGameFormViewModel> GetEditGameViewModelAsync(int id);
        Task<Game?> Update(EditGameFormViewModel model);
     /*   bool Delete(int id);*/
    }
}
