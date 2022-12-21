
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.DatabaseContext;
using Core.Interfaces;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.GamesController;


public class GamesController : Controller
{
    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View();
        //return View(await _gameRepository.GetAllGames());
    }

    [HttpPost]
    public Game CreateGame(string whitePlayer, string blackPlayer)
    {
        var game = new Game(whitePlayer, blackPlayer);
        _gameRepository.AddGame(game);
        return game;
    }

    [HttpGet]
    public async Task<IActionResult> GetGame(int id)
    {
        var games = await _gameRepository.GetGameById(id);
        return Ok(games);
    }
}
