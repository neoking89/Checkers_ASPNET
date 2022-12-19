using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Player
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public bool IsWhite { get; set; }
        public bool ToPlay { get; set; }

        public Player(string name, bool isWhite)
        {
            Name = name;
            IsWhite = isWhite;
            ToPlay = isWhite;
        }

	}
}
