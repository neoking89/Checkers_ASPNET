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

}


