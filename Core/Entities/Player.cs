using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Entities
{
	public class Player
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public bool ToPlay { get; set; }

        public Player(string name = "", Color color = Color.White)
        {
            Name = name;
            Color = color;
            ToPlay = color == Color.White ? true : false;
        }

	}
}
