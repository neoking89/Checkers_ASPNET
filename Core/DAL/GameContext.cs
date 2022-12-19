using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;


namespace Core.GameContext;
public class GameContext : DbContext
{
	public GameContext(DbContextOptions<GameContext> options) : base(options)
	{
        this.Database.EnsureCreated();
    }
	public DbSet<Game> Games { get; set; }
	public DbSet<Piece> Pieces { get; set; }
}
