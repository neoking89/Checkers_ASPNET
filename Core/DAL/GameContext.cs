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
    public GameContext
    (
        DbContextOptions<GameContext> options
    ) : base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var builder = new ConfigurationBuilder();
    //    var configuration = builder.Build();
    //    var connectionString = "server=.;Initial Catalog=Checkers;integrated security=true";
    //    optionsBuilder.UseSqlServer(connectionString);
    //    base.OnConfiguring(optionsBuilder);
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Game>()
    //    .Property(f => f.Id)
    //    .UseIdentityColumn();

    //    modelBuilder.Entity<Player>()
    //        .Property(f => f.Id)
    //        .UseIdentityColumn();

    //    //modelBuilder.Entity<Player>()
    //    //    .HasData(new Player { Id = 1, Name = "Player 1" });

    //    //modelBuilder.Entity<Game>()
    //    //    .HasData(new Game { Id = 1});



    //}
}


