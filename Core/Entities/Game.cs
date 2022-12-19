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
	public Dictionary<Player, Color> Players { get; set; } = new Dictionary<Player, Color>();
	public Board Board { get; set; }
	public DateTime TimeCreated { get; set; }
	public bool IsOver { get; set; }
	public Game(Player player1, Player player2)
	{
		Board = new Board();
		Board.CreateBoard();
		Board.InitializePiecesOnBoard();
		Players.Add(player1, Color.White);
		Players.Add(player2, Color.Black);
		TimeCreated = DateTime.Now;
		IsOver = false;
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
