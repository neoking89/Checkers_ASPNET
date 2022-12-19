using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

/// <summary>
/// Piece Class. Instantiate with a color.
/// </summary>
public class Piece 
{
	public Color Color { get; set; }
	public (int, int)? CurrentPosition { get; set; }
	public bool InPlay
	{
		get
		{
			return (CurrentPosition != null);
		}
	}

	public Piece(Color color, (int, int) position)
	{
		Color = color;
		CurrentPosition = position;
	}

	public override string ToString()
	{
		var color = Color == Color.White ? "W" : "B";
		return $"{color}, {CurrentPosition}";
	}

	public (int, int)? this[int y, int x]
	{
		get
		{
			return CurrentPosition;
		}
	}

	public void MovePiece((int, int) position)
	{
		// TODO: Check if move is valid
		CurrentPosition = position;
	}


}
