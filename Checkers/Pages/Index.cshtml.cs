using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Enums;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Checkers.Pages;
public class IndexModel : PageModel
{
	private readonly IPlayerRepository _playerRepository;
	[BindProperty] public string WhitePlayerName { get; set; } = "";
	[BindProperty] public string BlackPlayerName { get; set; } = "";
	public string ErrorMessage { get; set; } = "";
	public IndexModel(IPlayerRepository playerRepository)
	{
		_playerRepository = playerRepository;
	}

	public IActionResult OnGet()
	{
		return Page();
	}
	
	public IActionResult OnPost()
	{
		if (WhitePlayerName.IsNullOrEmpty() || BlackPlayerName.IsNullOrEmpty())
		{
			ErrorMessage = "Voer voor beide spelers een naam in";
			return Page();
		}
		if (ModelState.IsValid)
		{
			var tempString = WhitePlayerName + "_" + BlackPlayerName;
			return RedirectToPage("Game", "NewGame", new {playerNames = tempString});
		}
		else
		{
			var errors =
					from value in ModelState.Values
					where value.ValidationState == ModelValidationState.Invalid
					select value;
			foreach (var error in errors)
			{
				ErrorMessage += error.Errors[0].ErrorMessage;
			}
			return Page();
		}
	}
}