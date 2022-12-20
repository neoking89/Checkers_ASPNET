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
	public (int, int)? Position { get; set; }
    public bool InPlay
	{
		get
		{
			return (Position != null);
		}
	}
    public bool IsPromoted { get; set; } = false;

    public Piece(Color color, (int, int) position)
	{
		Color = color;
		Position = position;
	}

	public (int, int)? this[int y, int x]
	{
		get
		{
			return Position;
		}
	}

    public void Promote()
    {
        IsPromoted = true;
    }

	public override string ToString()
    {
        var color = Color == Color.White ? "white" : "black";
        return $"{color}, {Position}";
    }


}
