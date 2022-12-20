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
			foreach (Player player in Players)
			{
				// All Gamelogic here...
				Turn(player);
				//IsOver Check
			}
		}
        return IsOver;
    }


	public void Turn(Player player)
	{
        var playerPieces = GetPiecesForPlayer(player);
        foreach (var piece in playerPieces)
        {
			//GetPossibleMoves()?
        }
    }

	public Piece?[,] GetLastBoardState()
	{
		return Board.Pieces;
	}

    
	public void MovePiece((int, int) from, (int, int) to)
	{
		var piece = Board.Pieces[from.Item1, from.Item2];
		if (piece != null)
		{
			//ValidateMove(piece, to);
			Board.Pieces[from.Item1, from.Item2] = null;
			Board.Pieces[to.Item1, to.Item2] = piece;
		}
	}

    /// <summary>
    /// Return an IEnumerable of all the available color pieces for a specific player.
    /// </summary>
    public IEnumerable<Piece?> GetPiecesForPlayer(Player player)
	{
		IEnumerable<Piece?> enumerable = Board.Pieces.Cast<Piece?>();
		var playerPieces =
		from piece in enumerable
		where piece.Color == player.Color
		select piece;

		return playerPieces;
	}


}
