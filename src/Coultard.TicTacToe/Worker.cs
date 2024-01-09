using Coultard.DotNet.Logging;
using Coultard.TradoBot.Models;

namespace Coultard.TicTacToe;

public class Worker(ILoggerWrapper<Worker> logger)
    : BackgroundService
{
    private readonly ILoggerWrapper logger = logger;

    private static readonly string[] MarkDescriptions = { string.Empty, "O", "X" };
    private static readonly string[] ColumnDescriptions = { "A", "B", "C" };
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        logger.LogExtendedInfo("TicTacToe service start");

#if DEBUG
        // By putting a break point here we allow the option of attaching a debugger to the process before you continue or to see the output after pressing F5.
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
#endif
        Console.WriteLine("Tic Tac Toe Auto Play");
        Console.WriteLine("The computer will play itself with random moves.");

        // Normally we'd probably want some argument checks here e.g. /h for help or /start to start the game
        await PlayGame();
#if DEBUG
        Console.WriteLine("Game End");
        Console.ReadLine();
#endif
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogExtendedInfo("TicTacToe service stop");
        return base.StopAsync(cancellationToken);
    }
    
		private async Task PlayGame()
		{
			var game = new Game();

			// Play the game
			game.PlayGame();

			// Output the board
			DrawBoard(game.Moves);

			Console.WriteLine();
			Console.WriteLine("Moves in the form [{0} or {1}]: [Column: A, B or C], [Row: 1, 2 or 3]", Mark.Nought, Mark.Cross);
			Console.WriteLine();

			var showMoves = new List<Move>();
			var i = 1;
			
			// Output the moves
			foreach (var move in game.Moves)
			{
				Console.WriteLine("Move number: {0}", i);

				// Output the move coordinates
				Console.WriteLine("{0}: {1},{2}", move.Mark, ColumnDescriptions[move.Col], move.Row + 1);

				Console.WriteLine();

				// Add this move to the list of moves to show on the board
				showMoves.Add(move);

				DrawBoard(showMoves);
				Console.WriteLine();
				i++;
			}

			if (game.Board.IsDraw)
			{
				Console.WriteLine("Draw");
			}
			else
			{
				// Output the winner
				Console.WriteLine("Winner: {0}", MarkDescriptions[(int)game.Board.WinningMark]);
			}

			Console.WriteLine();
			Console.WriteLine("Play again? Y/N");
			var yesNo = Console.ReadLine();
			if (!string.IsNullOrEmpty(yesNo) && yesNo.Equals("y", StringComparison.InvariantCultureIgnoreCase))
			{
				await ExecuteAsync(CancellationToken.None);
			}
		}

		private static void DrawBoard(IReadOnlyCollection<Move> moves)
		{
			for (var row = 0; row < 3; row++)
			{
				var thisRowMoves = moves.Where(move => move.Row == row).ToList();
				DrawBoardLine(thisRowMoves);
				if (row < 2)
				{
					DrawBoardDivider();
				}
			}
		}

		private static void DrawBoardLine(IReadOnlyCollection<Move> moves)
		{
			var line = string.Empty;
			for (var column = 0; column < 3; column++)
			{
				var thisColumnMove = moves.FirstOrDefault(move => move.Col == column);
				if (thisColumnMove != null)
				{
					line += MarkDescriptions[(int)thisColumnMove.Mark];
				}
				else
				{
					line += " ";
				}

				if (column < 2)
				{
					line += "|";
				}
			}

			Console.WriteLine(line);
		}

		private static void DrawBoardDivider()
		{
			Console.WriteLine("-----");
		}
}