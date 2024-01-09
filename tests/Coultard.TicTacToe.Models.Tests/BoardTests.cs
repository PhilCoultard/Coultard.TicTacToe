using Coultard.TradoBot.Models;
using FluentAssertions;
using Xunit;

namespace Coultard.TicTacToe.Models.Tests
{
	public class BoardTests
	{
		#region Public Methods and Operators

		[Fact]
		public void AllSquaresUsedFalseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.AllSquaresUsed;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void AllSquaresUsedTrueTest()
		{
			// Arrange
			// Fill the board with marks
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);

			IBoard board = new Board(initBoard);

			// Act
			var result = board.AllSquaresUsed;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void BoardInitialiseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Assert
			board.Should().NotBeNull();
			foreach (int i in board)
			{
				i.Should().Be(0);
			}
		}

		[Fact]
		public void IsColOfOneMarkFalseTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 2] = (int)Mark.Nought;
			initBoard[1, 2] = (int)Mark.Cross;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsColOfOneMark;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsColOfOneMarkTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 2] = (int)Mark.Nought;
			initBoard[1, 2] = (int)Mark.Nought;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsColOfOneMark;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsColWithSameMarkFalseTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsColOfOneMark;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsColWithSameMarkTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 0] = (int)Mark.Cross;
			initBoard[1, 0] = (int)Mark.Cross;
			initBoard[2, 0] = (int)Mark.Cross;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsColOfOneMark;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsDiagonalOfOneMarkTopLeftToBotRightFalseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.IsDiagonalOfOneMarkTopLeftToBotRight;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsDiagonalOfOneMarkTopLeftToBotRightTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 0] = (int)Mark.Nought;
			initBoard[1, 1] = (int)Mark.Nought;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsDiagonalOfOneMarkTopLeftToBotRight;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsDiagonalOfOneMarkTopRightToBotLeftFalseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.IsDiagonalOfOneMarkTopRightToBotLeft;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsDiagonalOfOneMarkTopRightToBotLeftTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 2] = (int)Mark.Nought;
			initBoard[1, 1] = (int)Mark.Nought;
			initBoard[2, 0] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsDiagonalOfOneMarkTopRightToBotLeft;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsDrawFalseTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsDraw;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsDrawTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];

			// Row 0
			initBoard[0, 0] = (int)Mark.Cross;
			initBoard[0, 1] = (int)Mark.Cross;
			initBoard[0, 2] = (int)Mark.Nought;

			// Row 1
			initBoard[1, 0] = (int)Mark.Nought;
			initBoard[1, 1] = (int)Mark.Nought;
			initBoard[1, 2] = (int)Mark.Cross;

			// Row 2
			initBoard[2, 0] = (int)Mark.Cross;
			initBoard[2, 1] = (int)Mark.Cross;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsDraw;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsGameOverFalseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.IsGameOver;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsGameOverTrueTest()
		{
			// Arrange
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsGameOver;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsMoveValidFalseColTooLargeTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 5;
			IBoard board = new Board();

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseColTooSmallTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = -1;
			IBoard board = new Board();

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseMarkEmptyTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.IsMoveValid(Mark.Empty, 0, 0);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseRowTooLargeTest()
		{
			// Arrange
			const int MoveRow = 5;
			const int MoveCol = 2;
			IBoard board = new Board();

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseRowTooSmallTest()
		{
			// Arrange
			const int MoveRow = -1;
			const int MoveCol = 2;
			IBoard board = new Board();

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseSquarePopulatedDifferentMarkTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 2;
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[MoveRow, MoveCol] = (int)Mark.Cross;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidFalseSquarePopulatedSameMarkTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 2;
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[MoveRow, MoveCol] = (int)Mark.Cross;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsMoveValid(Mark.Cross, MoveRow, MoveCol);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsMoveValidTrueTest()
		{
			// Arrange
			const int MoveRow = 2;
			const int MoveCol = 2;
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[MoveRow, MoveCol] = (int)Mark.Empty;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsMoveValid(Mark.Nought, MoveRow, MoveCol);

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsPositionTakenFalse()
		{
			// Arrange
			const int Row = 0;
			const int Col = 0;
			IBoard board = new Board();

			// Act
			var result = board.IsPositionTaken(Row, Col);

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsPositionTakenTrue()
		{
			// Arrange
			const int Row = 0;
			const int Col = 0;
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[Row, Col] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsPositionTaken(Row, Col);

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsRowOfOneMarkFalseTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 0] = (int)Mark.Nought;
			initBoard[0, 1] = (int)Mark.Cross;
			initBoard[0, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsRowOfOneMark;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsRowOfOneMarkTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 0] = (int)Mark.Nought;
			initBoard[0, 1] = (int)Mark.Nought;
			initBoard[0, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsRowOfOneMark;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsRowWithSameMarkFalseTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsRowOfOneMark;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsRowWithSameMarkTrueTest()
		{
			// Arrange
			var initBoard = new int[Board.Rows, Board.Columns];
			initBoard[0, 0] = (int)Mark.Cross;
			initBoard[0, 1] = (int)Mark.Cross;
			initBoard[0, 2] = (int)Mark.Cross;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsRowOfOneMark;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsWinnerColTrueTest()
		{
			// Arrange
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 0] = (int)Mark.Nought;
			initBoard[1, 0] = (int)Mark.Nought;
			initBoard[2, 0] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsWinner;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsWinnerFalseTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.IsWinner;

			// Assert
			result.Should().BeFalse();
		}

		[Fact]
		public void IsWinnerRowTrueTest()
		{
			// Arrange
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[2, 0] = (int)Mark.Nought;
			initBoard[2, 1] = (int)Mark.Nought;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsWinner;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsWinnerTopLeftTrueTest()
		{
			// Arrange
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 0] = (int)Mark.Nought;
			initBoard[1, 1] = (int)Mark.Nought;
			initBoard[2, 2] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsWinner;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void IsWinnerTopRightTrueTest()
		{
			// Arrange
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 2] = (int)Mark.Nought;
			initBoard[1, 1] = (int)Mark.Nought;
			initBoard[2, 0] = (int)Mark.Nought;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.IsWinner;

			// Assert
			result.Should().BeTrue();
		}

		[Fact]
		public void WinnerColTest()
		{
			// Arrange
			const Mark ExpectedWinningMark = Mark.Nought;
			int[,] initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 0] = (int)ExpectedWinningMark;
			initBoard[1, 0] = (int)ExpectedWinningMark;
			initBoard[2, 0] = (int)ExpectedWinningMark;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.WinningMark;

			// Assert
			result.Should().Be(ExpectedWinningMark);
		}

		[Fact]
		public void WinnerDiagonalTopLeftToBotRightTest()
		{
			// Arrange
			const Mark ExpectedWinningMark = Mark.Nought;
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 0] = (int)ExpectedWinningMark;
			initBoard[1, 1] = (int)ExpectedWinningMark;
			initBoard[2, 2] = (int)ExpectedWinningMark;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.WinningMark;

			// Assert
			result.Should().Be(ExpectedWinningMark);
		}

		[Fact]
		public void WinnerDiagonalTopRightToBotLeftTest()
		{
			// Arrange
			const Mark ExpectedWinningMark = Mark.Nought;
			var initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 2] = (int)ExpectedWinningMark;
			initBoard[1, 1] = (int)ExpectedWinningMark;
			initBoard[2, 0] = (int)ExpectedWinningMark;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.WinningMark;

			// Assert
			result.Should().Be(ExpectedWinningMark);
		}

		[Fact]
		public void WinnerEmptyTest()
		{
			// Arrange
			IBoard board = new Board();

			// Act
			var result = board.WinningMark;

			// Assert
			result.Should().Be(Mark.Empty);
		}

		[Fact]
		public void WinnerRowTest()
		{
			// Arrange
			const Mark ExpectedWinningMark = Mark.Nought;
			int[,] initBoard = this.GetRandomlyPopulatedBoard(Board.Rows, Board.Columns);
			initBoard[0, 0] = (int)ExpectedWinningMark;
			initBoard[0, 1] = (int)ExpectedWinningMark;
			initBoard[0, 2] = (int)ExpectedWinningMark;
			IBoard board = new Board(initBoard);

			// Act
			var result = board.WinningMark;

			// Assert
			result.Should().Be(ExpectedWinningMark);
		}

		#endregion

		#region Methods

		private int[,] GetRandomlyPopulatedBoard(int rows, int cols)
		{
			var rand = new Random();
			var initBoard = new int[rows, cols];
			for (var row = 0; row < rows; row++)
			{
				for (var col = 0; col < cols; col++)
				{
					var mark = rand.Next(1, 3);
					initBoard[row, col] = mark;
				}
			}

			return initBoard;
		}

		#endregion
	}
}