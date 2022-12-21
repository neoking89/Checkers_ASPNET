//using Core.Entities;
//using Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Core.Interfaces;
//using Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using Core.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Enums;

namespace Checkers.Pages
{
    public class GameModel : PageModel
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        [BindProperty] public Game? Game { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public Piece?[,] CurrentBoardState { get; set; } = new Piece?[10, 10];
        public GameModel(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        public void OnGetNewGame(Game newGame)
        {
            if (newGame == null)
            {
                throw new NullReferenceException("newGame is null");
            }
            this.Game = newGame;
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                //Game = _gameRepository.CreateGame("White", "Black");
                //Players = _playerRepository.GetAllPlayers();
                //CurrentBoardState = Game.BoardState;
            }
        }
    }
}
