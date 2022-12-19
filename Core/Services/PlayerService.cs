using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services;
public interface IPlayerService
{
    //List<Player> GetPlayers();
    //void AddPlayer(Player player);
}

public class PlayerService : IPlayerService
{
    //    private readonly GameContext _context;

    //    public PlayerService(GameContext context)
    //    {
    //        _context = context;
    //    }

    //    public List<Player> GetPlayers()
    //    {
    //        return _context.Players.ToList();
    //    }

    //    public void AddPlayer(Player player)
    //    {
    //        _context.Players.Add(player);
    //        _context.SaveChanges();
    //    }
    //}
}