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
        
        public IActionResult OnGetNewGame(Game newGame)
        {
            if (newGame == null)
            {
                throw new NullReferenceException("newGame is null");
            }
            this.Game = newGame;
            WriteNewGameToDatabase(this.Game);
            return Page();
        }
        
        //GamesController
        public void WriteNewGameToDatabase(Game newGame)
        {
            _gameRepository.AddGame(newGame);
            foreach (var player in newGame.Players)
            {
                _playerRepository.AddPlayer(player);
            }
        }
        

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
            //if (ModelState.IsValid)
            //{
            //    //Game = _gameRepository.CreateGame("White", "Black");
            //    //Players = _playerRepository.GetAllPlayers();
            //    //CurrentBoardState = Game.BoardState;
            //}
        }
    }
}
