
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.DatabaseContext;
using Core.Interfaces;
using Core.Enums;


namespace Infrastructure.Repositories;


public class GameRepository : IGameRepository
{
    private readonly GameContext _context;

    public GameRepository(GameContext context)
    {
        _context = context;
    }

    // SHOULD BE IN CONTROLLER


    public async Task<Game?> GetGameById(int id)
    {
        return await _context.Games.FindAsync(id);
    }

    public void AddGame(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
    }

    //public async Task AddGame(Game game)
    //{
    //    _context.Games.Add(game);
    //    await _context.SaveChangesAsync();
    //}

    public async Task UpdateGame(Game game)
    {
        _context.Games.Update(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGame(Game game)
    {
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllGames()
    {
        _context.Games.RemoveRange(_context.Games);
        await _context.SaveChangesAsync();
    }
}
