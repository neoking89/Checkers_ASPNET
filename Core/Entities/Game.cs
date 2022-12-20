using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Core.Entities;

public class Game
{
	public int Id { get; set; }
    public string WhitePlayer { get; set; }
    public string BlackPlayer { get; set; }
    [NotMapped]
    public Board Board { get; set; }
	public DateTime TimeCreated { get; set; }
	public bool IsOver { get; set; }
    public ICollection<Player> Players { get; set; }
    public Game(string whitePlayer = "", string blackPlayer= "")
    {
        WhitePlayer = whitePlayer;
        BlackPlayer = blackPlayer;
        Board = new Board();
        Board.CreateBoard();
        Board.InitializePiecesOnBoard();
        TimeCreated = DateTime.Now;
        IsOver = false;
        Players = new List<Player>
        {
            new Player(WhitePlayer, Color.White),
            new Player(BlackPlayer, Color.Black)
        };

    }
	public void MovePiece((int, int) from, (int, int) to)
	{
		if (Board.CurrentPiecePositions.ContainsKey(from))
		{
			var piece = Board.CurrentPiecePositions[from];
			Board.CurrentPiecePositions.Remove(from);
			Board.CurrentPiecePositions.Add(to, piece);
        }
	}

    public Piece?[,] GetLastState()
    {
        var lastGameState = Board.CurrentPiecePositions;
        Piece?[,] board = new Piece?[10, 10];
        foreach (var (position, piece) in lastGameState)
        {
            board[position.Item1, position.Item2] = piece;
        }
        return board;
    }

    public void CheckLegalMoves()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                // DO CHECK HERE
            }
        }
    }

    


}
