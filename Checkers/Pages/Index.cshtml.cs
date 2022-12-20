using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Enums;

namespace Checkers.Pages
{
	public class IndexModel : PageModel
	{
        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        [BindProperty] public Game Game { get; set; }
        public List<Player> Players { get; set; }
        public Piece?[,] CurrentBoardState { get; set; } = new Piece?[10, 10];

        public IndexModel(IGameRepository gameRepository, IPlayerRepository playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }
        public void OnGet()
        {
            _playerRepository.DeleteAllPlayers();
            _gameRepository.DeleteAllGames();
            Game = _gameRepository.CreateGame("White", "Black");
        }
            
		
		
	}
}