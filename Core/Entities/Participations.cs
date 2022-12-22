using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Participation
	{
		public int PlayerId { get; set; }
		public int GameId { get; set; }
		public Player? Player { get; set; }
		public Game? Game { get; set; }
	}
}
