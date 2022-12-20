
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

    public Game CreateGame(string whitePlayer, string blackPlayer)
    {
        var game = new Game(whitePlayer, blackPlayer);
        Player player1 = new Player(whitePlayer, Color.White);
        Player player2 = new Player(blackPlayer, Color.Black);
        //_context.Players.AddRange(player1, player2);
        AddGame(game);
        return game;
    }

    public Game? GetGameById(int id)
    {
        return _context.Games.Find(id);
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

    public void DeleteAllGames()
    {
        _context.Games.RemoveRange(_context.Games);
        _context.SaveChanges();
    }


    // seperate gamerepo and boardrepo
    //public Piece?[,] GetLastGameState()
    //{
    //    Game lastGame = _context.Games.OrderByDescending(g => g.Id).First();
    //    var lastGameState = lastGame.Board.CurrentPiecePositions;
    //    Piece?[,] board = new Piece?[10, 10];
    //    foreach (var (position, piece) in lastGameState)
    //    {
    //        board[position.Item1, position.Item2] = piece;
    //    }
    //    return board;

    //}

}
