using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;

namespace Core.Services
{
    public class GameService : IGameService
	{
		private readonly IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;

		}
		
        public void CreateGame(Player player1, Player player2)
        {
            _repo.CreateGame(player1, player2);
        }

		public void GetGameById(int id)
		{
			_repo.GetGameById(id);
		}

		public void AddGame(Game game)
		{
			_repo.AddGame(game);
		}

		public void UpdateGame(Game game)
		{
			_repo.UpdateGame(game);
		}

		public void DeleteGame(Game game)
		{
			_repo.DeleteGame(game);
		}




	}
}
