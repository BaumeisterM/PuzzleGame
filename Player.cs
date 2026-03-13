namespace PuzzleGame;

public class Player
{
    private readonly Board _board;
    private readonly Score _score;
    private readonly string _datetime;
    private string _name;
    private int _countMove = 0;
    public ConsoleKey Up { get; private set; }
    public ConsoleKey Down { get; private set; }
    public ConsoleKey Left { get; private set; }
    public ConsoleKey Right { get; private set; }
    public int CountMove => _countMove;

    public Player(Board board, Score score)
    {
        Up = ConsoleKey.UpArrow;
        Down = ConsoleKey.DownArrow;
        Left = ConsoleKey.LeftArrow;
        Right = ConsoleKey.RightArrow;
        _board = board;
        _score = score;
        _datetime = DateTime.Now.ToString("dd.MM.yyyy");
    }

    public void Move()
    {
        _board.DisplayBoard(_countMove);
        while (!_board.IsSolved)
        {
            var key = Console.ReadKey(true).Key;

            (int rowChange, int columnChange) = key switch
            {
                ConsoleKey.DownArrow => (-1, 0),
                ConsoleKey.UpArrow => (1, 0),
                ConsoleKey.RightArrow => (0, -1),
                ConsoleKey.LeftArrow => (0, 1),
                _ => (0, 0) // if press no valid key
            };

            if (rowChange != 0 || columnChange != 0)
            {
                MovePlayer(rowChange, columnChange);
                _board.DisplayBoard(_countMove);
            }
        }
        _name = ShowWinningMessage();
        _score.DisplayScore(_name, _countMove, _datetime, _board); // methode noch nicht fertig
    }

    private void MovePlayer(int rowChange, int columnChange)
    {
        if (_board.TryMove(rowChange, columnChange))
            _countMove++;
    }

    public string BlinkInputThreeLetters()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.CursorVisible = false;
        string input = "";
        bool showCursor = true;

        while (input.Length < 3)
        {
            // build screen fill underscore with letters
            string filled = input;
            string display = "      Name: " + filled + (showCursor ? "_" : " ") + new string('_', 2 - input.Length);

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(display);

            showCursor = !showCursor;

            // Wait 500ms but validate if button was pressed
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (char.IsLetter(key.KeyChar))
                    {
                        input += char.ToUpper(key.KeyChar);
                    }
                    break;
                }
            }
        }
        Console.CursorVisible = true;
        return input;
    }

    public string ShowWinningMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"          ____ ___  _   _  ____ ____     _  _____ _   _ _        _  _____ ___ ___  _   _ ");
        Console.WriteLine(@"         / ___/ _ \| \ | |/ ___|  _ \   / \|_   _| | | | |      / \|_   _|_ _/ _ \| \ | |");
        Console.WriteLine(@"        | |  | | | |  \| | |  _| |_) | / _ \ | | | | | | |     / _ \ | |  | | | | |  \| |");
        Console.WriteLine(@"        | |__| |_| | |\  | |_| |  _ < / ___ \| | | |_| | |___ / ___ \| |  | | |_| | |\  |");
        Console.WriteLine(@"         \____\___/|_| \_|\____|_| \_/_/   \_\_|  \___/|_____/_/   \_\_| |___\___/|_| \_|");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
        var name = BlinkInputThreeLetters();
        return name;
    }
}
