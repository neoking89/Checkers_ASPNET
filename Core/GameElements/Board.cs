using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GameElements;


/// <summary>
/// This class is responsible for creating the board and the pieces.
/// </summary>
public class Board
{
    public Color[,] Squares { get; set; } = new Color[10, 10];
    public Board()
    {
        CreateSquares();
    }

    /// <summary>
    /// Create a board.
    /// </summary>
    public void CreateSquares()
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

    public Board this[int y, int x]
    {
        get
        {
            return this[y, x];
        }
    }
}
