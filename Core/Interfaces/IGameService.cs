using Core.Entities;

namespace Core.Interfaces;

public interface IGameService
{
    void AddGame(Game game);
    void DeleteGame(Game game);
    void GetGameById(int id);
    void UpdateGame(Game game);
}