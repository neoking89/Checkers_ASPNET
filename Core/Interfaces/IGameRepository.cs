using Core.Entities;

namespace Core.Interfaces;

public interface IGameRepository
{
    void AddGame(Game game);
    Game CreateGame(string whitePlayer, string blackPlayer);
    void DeleteGame(Game game);
    Game GetGameById(int id);
    void UpdateGame(Game game);
    void DeleteAllGames();
}