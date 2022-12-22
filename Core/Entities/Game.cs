using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.GameElements;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Game
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int GameId { get; set; }
    public string? WhitePlayer { get; set; }
    public string? BlackPlayer { get; set; }
    public DateTime TimeCreated { get; set; }
    public bool IsOver { get; set; }
    [NotMapped]
    public Board Board { get; set; } = new Board();
    [NotMapped]
    public ICollection<Player> Players { get; set; } = new List<Player>();
    [NotMapped]
    public ICollection<Piece> Pieces { get; set; } = new List<Piece>();
    [NotMapped]
    public ICollection<string> PlayedMoves { get; set; } = new List<string>();
    public Game()
    {
        InitializePiecesOnBoard(Board);
        TimeCreated = DateTime.Now;
        IsOver = false;
    }
    public Game(string whitePlayer = "", string blackPlayer = "") : base()
    {
        WhitePlayer = whitePlayer;
        BlackPlayer = blackPlayer;
        Players = new List<Player>
        {
            new Player(whitePlayer, Color.White),
            new Player(blackPlayer, Color.Black)
        };
    }

    /// <summary>
	/// Start a game of checkers.
	/// </summary>
	public bool Start()
    {
        while (!IsOver)
        {
            if (Players != null)
            {
                foreach (Player player in Players)
                {
                    // All Gamelogic here...
                    Turn(player);
                    //IsOver Check
                }
            }

        }
        return IsOver;
    }


    public void Turn(Player player)
    {
        foreach (var piece in Pieces)
        {
            //GetPossibleMoves()?
        }
    }

    /// <summary>
    /// Creates pieces on the board
    /// </summary>
    public void InitializePiecesOnBoard(Board board)
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if ((y <= 3 || y >= 6) && board.Squares[y, x] == Color.Black)
                {
                    Pieces.Add(new Piece(color: y <= 3 ? Color.White : Color.Black, x, y));
                }
            }
        }
    }
    
}
	
 //   public void MovePiece((int, int) from, (int, int) to)
	//{
	//	var piece = Pieces[from.Item1, from.Item2];
	//	if (piece != null)
	//	{
	//		//ValidateMove(piece, to);
	//		Pieces[from.Item1, from.Item2] = null;
	//		Pieces[to.Item1, to.Item2] = piece;
	//	}
	//}

    /// <summary>
    /// Return an IEnumerable of all the available color pieces for a specific player.
    /// </summary>

//}
