using Core.Entities;
using Core.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;


public class PlayerRepository : IPlayerRepository
{
    private readonly GameContext _context;

    public PlayerRepository(GameContext context)
    {
        _context = context;
    }


    public async Task AddPlayer(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Player>> GetAllPlayers()
    {
        return await _context.Players.ToListAsync();
    }

    public async Task<Player?> GetPlayerById(int id)
    {
        return await _context.Players.FindAsync(id);
    }

    public async Task<Player?> GetPlayerByName(string name)
    {
        return await _context.Players.FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task UpdatePlayer(Player player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllPlayers()
    {
        _context.Players.RemoveRange(_context.Players);
        await _context.SaveChangesAsync();
    }
}