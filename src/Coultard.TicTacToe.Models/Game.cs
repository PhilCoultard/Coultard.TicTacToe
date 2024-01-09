namespace Coultard.TradoBot.Models
{
	/// <summary>
	///     Represents the Tic Tac Toe game.
	/// </summary>
	public class Game
	{
		#region Fields

		private readonly IBoard board;

		private readonly List<Move> moves = new List<Move>();

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		public Game()
			: this(new Board())
		{
		}

		public List<Move> Moves
		{
			get
			{
				return moves;
			}
		}

		public void PlaceMove(Mark mark, int row, int col)
		{
			if (!board.IsMoveValid(mark, row, col))
			{
				return;
			}

			board[row, col] = (int)mark;
			moves.Add(new Move(mark, row, col));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Game"/> class.
		/// </summary>
		/// <param name="board">The board.</param>
		/// <remarks>Used to unit test this class with a specific board.</remarks>
		public Game(IBoard board)
		{
			this.board = board;
		}

		#endregion

		#region Public Properties

		public IBoard Board
		{
			get
			{
				return board;
			}
		}

		#endregion

		#region Public Methods and Operators
		// TODO: We'd probably want to split this up to allow moves to be placed from an external call e.g. from the console app. 
		public void PlayGame(Mark startMark = Mark.Nought)
		{
			var rand = new Random();
			var mark = startMark;
			var maxRowValue = board.GetLength(0);
			var maxColValue = board.GetLength(1);

			while (!board.IsWinner)
			{
				int row;
				int col;
				do
				{
					row = rand.Next(0, maxRowValue);
					col = rand.Next(0, maxColValue);
				}
				while (!board.IsMoveValid(mark, row, col));

				PlaceMove(mark, row, col);
				mark = mark == Mark.Nought ? Mark.Cross : Mark.Nought;
			}
		}

		#endregion
	}
}