namespace Coultard.TradoBot.Models
{
	/// <summary>
	///     Represents a game move.
	/// </summary>
	public class Move
	{
		#region Constructors and Destructors

		public Move(Mark mark, int row, int col)
		{
			this.Mark = mark;
			this.Row = row;
			this.Col = col;
		}

		#endregion

		#region Public Properties

		public int Col { get; set; }

		public Mark Mark { get; set; }

		public int Row { get; set; }

		#endregion
	}
}