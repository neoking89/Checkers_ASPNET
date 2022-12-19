using Core.Entities;

namespace Core.Interfaces;

public interface IGameRepository
{
    void AddGame(Game game);
    void CreateGame(string whitePlayer, string blackPlayer);
    void DeleteGame(Game game);
    void GetGameById(int id);
    void UpdateGame(Game game);
}