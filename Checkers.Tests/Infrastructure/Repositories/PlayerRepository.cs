using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Infrastructure.Repositories;
using Core.Interfaces;
using Core.Entities;
using Core.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Core.Enums;


namespace Checkers.Tests.Infrastructure.Repositories;


[TestFixture]
public class PlayerRepositoryTests
{
    private readonly IPlayerRepository _playerRepository;
    private readonly GameContext _context;

	public PlayerRepositoryTests()
	{
		var options = new DbContextOptionsBuilder<GameContext>()
			.UseInMemoryDatabase("tempdb")
			.Options;

		_context = new GameContext(options);
		_playerRepository = new PlayerRepository(_context);
	}

	[Test]
    public async Task PlayerRepositoryAddPlayers_PlayersAddedToDbAndFoundById_ShouldBeEqual()
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

		// Act
        await _playerRepository.AddPlayer(player1);
		await _playerRepository.AddPlayer(player2);

		// Assert
		var expected1 = player1;
		var actual1 = await _playerRepository.GetPlayerById(1);
		Assert.AreEqual(expected1, actual1);

		var expected2 = player2;
		var actual2 = await _playerRepository.GetPlayerById(2);
		Assert.AreEqual(expected2, actual2);
	}	

}

