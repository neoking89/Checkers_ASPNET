using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.Xml;

namespace Core.DatabaseContext;
public class GameContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public GameContext
    (
        DbContextOptions<GameContext> options
    ) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participation>()
             .HasKey(cs => new { cs.GameId, cs.PlayerId });

        modelBuilder.Entity<Participation>()
            .HasOne(cs => cs.Game)
            .WithMany(c => c.Players)
            .HasForeignKey(cs => cs.GameId);

        modelBuilder.Entity<Participation>()
            .HasOne(cs => cs.Player)
            .WithMany(s => s.Games)
            .HasForeignKey(cs => cs.PlayerId);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        base.OnConfiguring(optionsBuilder);
    }
}


