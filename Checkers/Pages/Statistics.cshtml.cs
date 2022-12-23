using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Entities;

namespace Checkers.Pages
{
    public class StatisticsModel : PageModel
    {
        private readonly IPlayerRepository _playerRepository;
        [BindProperty] public string Name { get; set; }

        public StatisticsModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            var players = await _playerRepository.GetAllPlayers();
            this.Name = players.Last().Name ?? "Niemand";
            return Page();
        }

    }
}
