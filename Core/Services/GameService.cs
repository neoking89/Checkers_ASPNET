using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class GameService
	{
		private readonly IGameRepository _repo;

		public GameService(IGameRepository repo)
		{
			_repo = repo;
		}

        public void CreateGame(string blackPlayer, string whitePlayer)
        {
            _repo.CreateGame(blackPlayer, whitePlayer);
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
