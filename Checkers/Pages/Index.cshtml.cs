using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Enums;

namespace Checkers.Pages;
public class IndexModel : PageModel
{
    private readonly IPlayerRepository _playerRepository;
    [BindProperty] public string WhitePlayerName { get; set; } = "";
    [BindProperty] public string BlackPlayerName { get; set; } = "";
    public IndexModel(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public void OnGet()
    {
        
    }
    
    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            //_playerRepository.AddPlayer(whitePlayer);
            //_playerRepository.AddPlayer(blackPlayer);
            return RedirectToPage("Game", "NewGame", new Game(WhitePlayerName, BlackPlayerName));
        }
        else
        {
            throw new Exception("Invalid model state" + ModelState.ValidationState);
            //return Page();
        }
    }
}