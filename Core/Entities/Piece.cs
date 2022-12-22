using Core.Enums;
using Core.GameElements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

/// <summary>
/// Piece Class. Instantiate with a color.
/// </summary>
public class Piece 
{
    [Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public Color Color { get; set; }
    public bool InPlay { get; set; }
    public bool IsPromoted { get; set; } = false;
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game? Game { get; set; }

    [NotMapped]
	public (int?, int?) Position
	{
		get
		{
			return (X, Y);
		}
		set
		{
			X = value.Item1;
			Y = value.Item2;
		}
	}
	private int? _x;
    public int? X
    {
        get 
        {
            if (_x < 0 || _x > 9)
            {
                throw new ArgumentOutOfRangeException("X must be between 0 and 9");
            }
            return InPlay? _x : null; 
        }
        set { _x = value; }
    }
    private int? _y;
    public int? Y
    {
        get 
        {
            if (_y < 0 || _y > 9)
            {
                throw new ArgumentOutOfRangeException("Y must be between 0 and 9");
            }
            return InPlay ? _y : null; 
        }
        set { _y = value; }
    }

    public Piece() { }
    public Piece(Color color, int x, int y) 
    {
        Color = color;
        X = x;
        Y = y;
        InPlay = true;
    }
    

    public void Promote()
    {
        IsPromoted = true;
    }

	public override string ToString()
    {
        var color = Color == Color.White ? "white" : "black";
        return $"{color}, {X}, {Y}";
    }
}
