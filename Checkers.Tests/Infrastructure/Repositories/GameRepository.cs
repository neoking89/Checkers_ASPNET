using Core.Entities;
using Core.DatabaseContext;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Checkers.Tests.Infrastructure.Repositories;



[TestFixture]
public class GameRepositoryTests
{
	private readonly IGameRepository _gameRepository;
	private readonly GameContext _context;

	public GameRepositoryTests()
	{
		var options = new DbContextOptionsBuilder<GameContext>()
			.UseInMemoryDatabase("tempdb")
			.Options;

		_context = new GameContext(options);
		_gameRepository = new GameRepository(_context);
	}

	[Test]
	public async Task GameRepositoryAddGame_gamesAddedToDbAndFoundSuccesfullyById_ShouldBelEqual()
	{
		// Arrange
		var player1 = new Player
		{
			Id = 1,
			Name = "WhitePlayer",
			Color = Color.White
		};

		var player2 = new Player
		{
			Id = 2,
			Name = "BlackPlayer",
			Color = Color.Black
		};
		var game = new Game
		{
			Id = 1,
			WhitePlayer = player1,
			BlackPlayer = player2,
		};

		// Act
		await _gameRepository.AddGame(game);


		// Assert
		//Assert.Fail();
		var expected1 = game;
		var actual1 = await _gameRepository.GetGameById(1);
		Assert.AreEqual(expected1, actual1);
	}

}
