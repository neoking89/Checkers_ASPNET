using Core.Entities;
using Core.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Repositories;


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

    public void DeleteAllPlayers()
    {
        _context.Players.RemoveRange(_context.Players);
        _context.SaveChanges();
    }
}