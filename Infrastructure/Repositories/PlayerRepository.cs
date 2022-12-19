using Core.Entities;
using Core.GameContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public interface IPlayerRepository
{
    List<Player> GetAllPlayers();
    Player GetPlayerById(int id);
}


public class PlayerRepository : IPlayerRepository
{
    private readonly GameContext _context;

    public PlayerRepository(GameContext context)
    {
        _context = context;
    }

    public List<Player> GetAllPlayers()
    {
        return _context.Players.ToList();
    }

    public Player? GetPlayerById(int id)
    {
        return _context.Players.Find(id);
    }

}