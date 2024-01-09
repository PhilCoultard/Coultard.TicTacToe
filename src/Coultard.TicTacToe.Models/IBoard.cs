using System.Collections;

namespace Coultard.TradoBot.Models
{
	public interface IBoard : IEnumerable
	{
		int this[int x, int y]
		{
			get;
			set;
		}
		#region Public Properties

		bool AllSquaresUsed { get; }

		bool IsColOfOneMark { get; }

		bool IsDiagonalOfOneMarkTopLeftToBotRight { get; }

		bool IsDiagonalOfOneMarkTopRightToBotLeft { get; }

		bool IsDraw { get; }

		bool IsGameOver { get; }

		bool IsRowOfOneMark { get; }

		bool IsWinner { get; }

		Mark WinningMark { get; }

		#endregion

		#region Public Methods and Operators

		bool IsMoveValid(Mark mark, int row, int col);

		bool IsPositionTaken(int row, int col);

		#endregion

		int GetLength(int i);
	}
}