using Coultard.TradoBot.Models;
using FluentAssertions;
using Xunit;

namespace Coultard.TicTacToe.Models.Tests
{
	/// <summary>
	/// Generally there could be more/better tests for the Game class. i.e. by injecting the IBoard as a Mocked/Faked
	/// object (e.g. using Moq) and thereby testing the Game class alone rather than using the Board class implementation.
	/// These are integration tests: integrating the Game and Board classes.
	/// </summary>
	
	public class GameTests
	{
		#region Public Methods and Operators

		[Fact]
		public void PlaceMoveTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 1;
			const Mark MoveMark = Mark.Nought;
			var game = new Game();

			// Act
			game.PlaceMove(Mark.Nought, MoveRow, MoveCol);

			// Assert
			game.Board[MoveRow, MoveCol].Should().Be((int)MoveMark);
		}

		[Fact]
		public void PlaceMoveInValidTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 2;
			const Mark InitialMark = Mark.Cross;
			const Mark MoveMark = Mark.Nought;

			var init = new int[Board.Rows, Board.Columns];
			init[MoveRow, MoveCol] = (int)InitialMark;
			var initBoard = new Board(init);
			var game = new Game(initBoard);

			// Act
			game.PlaceMove(MoveMark, MoveRow, MoveCol);

			// Assert
			game.Board[MoveRow, MoveCol].Should().Be((int)InitialMark);
		}

		[Fact]
		public void PlaceMoveAddsMoveToList()
		{
			// Arrange
			const Mark ExpectedMark = Mark.Nought;
			const int MoveRow = 2;
			const int MoveCol = 1;

			var game = new Game();

			// Act
			game.PlaceMove(ExpectedMark, MoveRow, MoveCol);

			// Assert
			game.Moves.Should().NotBeNull();
			var firstMove = game.Moves.FirstOrDefault();
			firstMove.Should().NotBeNull();
			firstMove?.Mark.Should().Be(ExpectedMark);
			firstMove?.Row.Should().Be(MoveRow);
			firstMove?.Col.Should().Be(MoveCol);
		}

		[Fact]
		public void PlaceMoveInvalidEmptyDoesntAddMoveToList()
		{
			// Arrange
			var game = new Game();

			// Act
			game.PlaceMove(Mark.Empty, 1, 1);

			// Arrange
			game.Moves.Count().Should().Be(0);
		}

		[Fact]
		public void PlaceMoveInvalidUsedSquareDoesntAddMoveToList()
		{
			// Arrange
			var game = new Game();

			// Act
			game.PlaceMove(Mark.Nought, 1, 1);
			game.PlaceMove(Mark.Cross, 1, 1);

			// Arrange
			game.Moves.Count().Should().Be(1);
		}


		[Fact]
		public void PlayGameTest()
		{
			// Arrange
			var game = new Game();

			// Act
			game.PlayGame();

			// Assert
			game.Moves.Count().Should().BeGreaterThan(4);
			game.Board.IsGameOver.Should().BeTrue();

			// NB: we shouldn't be using another method to establish the outcome of this test.
			// However, as IsDraw has been tested I feel comfortable doing this.
			if (!game.Board.IsDraw)
			{
				game.Board.WinningMark.Should().NotBe(Mark.Empty);
			}
			else
			{
				game.Board.WinningMark.Should().Be(Mark.Empty);
			}
		}

		[Fact]
		public void StartGameTest()
		{
			// Arrange
			var game = new Game();

			// Assert
			game.Should().NotBeNull();
			game.Board.Should().NotBeNull();
			foreach (int i in game.Board)
			{
				i.Should().Be(0);
			}
		}

		#endregion
	}
}