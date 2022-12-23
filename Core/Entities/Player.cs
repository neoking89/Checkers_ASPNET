using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.GameElements;

namespace Core.Entities
{
	public class Player
	{
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string? Name { get; set; }
        public Color Color { get; set; }
        public bool ToPlay { get; set; }
        public Stopwatch TimeUsed { get; set; } = new();
		//public ICollection<Participation> Participations { get; set; }
		public Player() { }
        public Player(string name = "", Color color = Color.White) 
        {
            Name = name;
            Color = color;
            ToPlay = color == Color.White ? true : false;
        }

		public void StartClock()
		{
			TimeUsed.Start();
		}

		public void StopClock()
		{
			TimeUsed.Stop();
		}

		public void ResetClock()
		{
			TimeUsed.Reset();
		}

		public void SwitchTurn()
		{
			ToPlay = !ToPlay;
		}

		public override string ToString()
        {
            return $"{Name} ({Color})";
        }

        

        //public static Board PromptMove(Player player, Board board)
        //    // Replace by REST later!
        //{
        //    Console.WriteLine("Enter the position of the piece you want to move.");
        //    while
        //    var input = Console.ReadLine();
        //    var position = (int.Parse(input[0].ToString()), int.Parse(input[1].ToString()));
        //    var piece = board[position];
        //    if (piece.Color != player.Color)
        //    {
        //        Console.WriteLine("That is not your piece.");
        //        return PromptMove(board);
        //    }
        //    return board;
        //}

    }


}
