using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;


/// <summary>
/// This class is responsible for creating the board and the pieces.
/// </summary>
public class Board
{
	public int Id { get; set; }
	[NotMapped]
	public Color[,] Squares { get; set; } = new Color[10, 10];
	[NotMapped]
	public Piece?[,] Pieces { get; set; } = new Piece?[10,10];
    
	public Board()
	{
	}
	/// <summary>
	/// Creates pieces on the board
	/// </summary>
	public void InitializePiecesOnBoard()

	{
		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				if ((y < 3 || y > 6) && Squares[y, x] == Color.Black)
				{
					Pieces[y, x] = new Piece(color: y < 3 ? Color.White : Color.Black, position: (y,x));   
				}
				else
				{
                    Pieces[y, x] = null;
                }
			}
		}
	}
	/// <summary>
	/// Create a board.
	/// </summary>
	public void CreateBoard()
	{
		for (int i = 0; i < Squares.GetLength(dimension: 0); i++)
		{
			for (int j = 0; j < Squares.GetLength(1); j++)
			{
				bool ColorChoice = (i + j) % 2 == 0;
				Squares[i, j] = ColorChoice ? Color.Black : Color.White;

			}
		}
	}
	

	public Piece? this[int y, int x]
	{
		get
		{
            return Pieces[y, x];
        }
	}

}
