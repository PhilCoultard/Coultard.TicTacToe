using System.Collections;

namespace Coultard.TradoBot.Models
{
	/// <summary>
	///     Represents the Tic Tac Toe board.
	/// </summary>
	public class Board : IBoard
	{
		#region Constants

		public const int Columns = 3;

		public const int Rows = 3;

		#endregion

		#region Fields

		private readonly int[,] board;

		private Mark winningMark;

		#endregion

		#region Constructors and Destructors

		public Board()
		{
			this.board = new int[Rows, Columns];
		}

		public Board(int[,] initBoard)
		{
			this.board = initBoard;
		}

		#endregion

		#region Public Properties

		public int this[int x, int y]
		{
			get
			{
				return board[x, y];
			}
			set
			{
				board[x, y] = value;
			}
		}

		public bool AllSquaresUsed
		{
			get
			{
				for (var row = 0; row < board.GetLength(0); row++)
				{
					for (int col = 0; col < board.GetLength(1); col++)
					{
						if (!IsPositionTaken(row, col))
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		public bool IsColOfOneMark
		{
			get
			{
				// Iterate columns looking for a populated mark. 
				// If/when found iterate the rows ensuring a match with previous.
				for (var col = 0; col < this.board.GetLength(1); col++)
				{
					if (!this.IsPositionTaken(0, col))
					{
						// No mark so no winner in this col
						continue;
					}

					var startMark = this.board[0, col];

					// Iterate the rows
					for (var row = 1; row < this.board.GetLength(0); row++)
					{
						if (this.board[row, col] != startMark)
						{
							// doesn't match so move to next COL (outer loop)
							break;
						}

						if (row != this.board.GetLength(0) - 1)
						{
							continue;
						}

						winningMark = (Mark)startMark;
						return true;
					}
				}

				return false;
			}
		}

		public bool IsDiagonalOfOneMarkTopLeftToBotRight
		{
			get
			{
				if (!IsPositionTaken(0, 0))
				{
					return false;
				}

				var startMark = board[0, 0];
				var diagonalMatch = board[1, 1] == startMark && board[2, 2] == startMark;

				if (diagonalMatch)
				{
					winningMark = (Mark)startMark;
				}

				return diagonalMatch;
			}
		}

		public bool IsDiagonalOfOneMarkTopRightToBotLeft
		{
			get
			{
				if (!IsPositionTaken(0, 2))
				{
					return false;
				}

				var startMark = board[0, 2];
				var diagonalMatch = board[1, 1] == startMark && board[2, 0] == startMark;

				if (diagonalMatch)
				{
					winningMark = (Mark)startMark;
				}

				return diagonalMatch;
			}
		}

		public bool IsDraw
		{
			get
			{
				return IsGameOver && !IsWinner;
			}
		}

		public bool IsGameOver
		{
			get
			{
				return AllSquaresUsed || IsWinner;
			}
		}

		public bool IsRowOfOneMark
		{
			get
			{
				// Iterate rows looking for a populated mark. 
				// If/when found iterate the columns ensuring a match with previous.
				for (var row = 0; row < this.board.GetLength(0); row++)
				{
					if (!this.IsPositionTaken(row, 0))
					{
						// No mark so no winner in this row
						continue;
					}

					var startMark = this.board[row, 0];

					// Iterate the columns
					for (var col = 1; col < this.board.GetLength(1); col++)
					{
						if (this.board[row, col] != startMark)
						{
							// no match so move to next ROW (outer loop)
							break;
						}

						if (col != this.board.GetLength(1) - 1)
						{
							continue;
						}

						// unbroken matching so return true;
						winningMark = (Mark)startMark;
						return true;
					}
				}

				return false;
			}
		}

		public bool IsWinner
		{
			get
			{
				return IsRowOfOneMark || IsColOfOneMark || IsDiagonalOfOneMarkTopLeftToBotRight
				           || IsDiagonalOfOneMarkTopRightToBotLeft;
			}
		}

		public Mark WinningMark
		{
			get
			{
				if (winningMark == Mark.Empty)
				{
					// Game may have finished, so get 
					winningMark = GetWinner();
				}

				return winningMark;
			}
		}

		#endregion

		#region Public Methods and Operators

		public bool IsMoveValid(Mark mark, int row, int col)
		{
			if (mark == Mark.Empty 
				|| row < 0 
				|| row > board.GetLength(0) 
				|| col < 0 
				|| col > board.GetLength(1))
			{
				return false;
			}

			return !IsPositionTaken(row, col);
		}

		public bool IsPositionTaken(int row, int col)
		{
			return board[row, col] != (int)Mark.Empty;
		}

		public IEnumerator GetEnumerator()
		{
			return board.GetEnumerator();
		}

		public int GetLength(int i)
		{
			return board.GetLength(i);
		}

		#endregion

		#region Methods

		private Mark GetWinner()
		{
			return this.IsWinner ? this.winningMark : Mark.Empty;
		}

		#endregion
	}
}