using Core.Entities;
using Core.Enums;

namespace Core.Interfaces;

public interface IPlayerRepository
{
    Player CreatePlayer(string name, Color color);
    void AddPlayer(Player player);
    List<Player> GetAllPlayers();
    Player GetPlayerById(int id);
    void DeleteAllPlayers();
}
