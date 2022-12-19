
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.GameContext;
using Core.Interfaces;


namespace Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameContext _context;

    public GameRepository(GameContext context)
    {
        _context = context;
    }

    public void CreateGame(string whitePlayer, string blackPlayer)
    {
        var game = new Game(whitePlayer, blackPlayer);
        Player player1 = new Player(whitePlayer, true);
        Player player2 = new Player(blackPlayer, false);
        _context.Players.AddRange(player1, player2);
        _context.Games.Add(game);
        _context.SaveChanges();
    }

    public void GetGameById(int id)
    {
        _context.Games.Find(id);
    }

    public void AddGame(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
    }

    public void UpdateGame(Game game)
    {
        _context.Games.Update(game);
        _context.SaveChanges();
    }

    public void DeleteGame(Game game)
    {
        _context.Games.Remove(game);
        _context.SaveChanges();
    }

}
