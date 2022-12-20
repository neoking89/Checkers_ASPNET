using Core.Entities;

namespace Core.Interfaces;

public interface IPlayerRepository
{
    List<Player> GetAllPlayers();
    Player GetPlayerById(int id);
    void DeleteAllPlayers();
}
