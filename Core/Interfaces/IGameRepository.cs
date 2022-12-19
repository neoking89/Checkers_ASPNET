using Core.Entities;

namespace Core.Interfaces;

public interface IGameRepository
{
	void AddGame(Game game);
	void CreateGame(Player player1, Player player2);
	void DeleteGame(Game game);
	void GetGameById(int id);
	void UpdateGame(Game game);
}
