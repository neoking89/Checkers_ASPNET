using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IGameRepository
{
    void AddGame(Game game);
    Task DeleteAllGames();
    Task DeleteGame(Game game);
    Task<Game?> GetGameById(int id);
    Task UpdateGame(Game game);
}
