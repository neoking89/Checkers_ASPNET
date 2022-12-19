using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Entities;

public class Game
{
	public int Id { get; set; }
    public string WhitePlayer { get; set; }
    public string BlackPlayer { get; set; }
    public Board Board { get; set; }
	public DateTime TimeCreated { get; set; }
	public bool IsOver { get; set; }
    public ICollection<Player> Players { get; set; }
    public Game(string whitePlayer, string blackPlayer)
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
            new Player(whitePlayer, true),
            new Player(blackPlayer, false)
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
}
