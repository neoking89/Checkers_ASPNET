using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IPlayerRepository
{
    Task AddPlayer(Player player);
    Task DeleteAllPlayers();
    Task<List<Player>> GetAllPlayers();
    Task<Player?> GetPlayerById(int id);
    Task<Player?> GetPlayerByName(string name);
    Task UpdatePlayer(Player player);
}