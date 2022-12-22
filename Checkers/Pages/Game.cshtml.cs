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
        public GameModel(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        
        public async Task<IActionResult> OnGetNewGame(string? playerNames)
        {
            if (playerNames != null)
            {
                string[] splittedString = playerNames.Split("_");
                var whitePlayer = new Player(splittedString[0], Color.White);
                var blackPlayer = new Player(splittedString[1], Color.Black);
                this.Game = new Game(whitePlayer, blackPlayer);
				await WriteNewGameToDatabase(this.Game);
            }
            return Page();
        }
        
        //Need to move to GamesController
        public async Task WriteNewGameToDatabase(Game newGame)
        {
            await _gameRepository.AddGame(newGame);
            await _playerRepository.AddPlayer(newGame.WhitePlayer!);
            await _playerRepository.AddPlayer(newGame.BlackPlayer!);
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
