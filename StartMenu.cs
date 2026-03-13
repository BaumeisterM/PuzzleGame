namespace PuzzleGame;

public class StartMenu
{
    private readonly Score _score;

    public StartMenu(Score score)
    {
        _score = score;
    }

    public void DisplayStartMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(@"        __            __  ______  _        _____   ____   __  __  ______ ");
        Console.WriteLine(@"        \ \    __    / / |  ____|| |      / ____| / __ \ |  \/  ||  ____|");
        Console.WriteLine(@"         \ \  /  \  / /  | |__   | |     | |     | |  | || \  / || |__   ");
        Console.WriteLine(@"          \ \/ /\ \/ /   |  __|  | |     | |     | |  | || |\/| ||  __|  ");
        Console.WriteLine(@"           \  /  \  /    | |____ | |____ | |____ | |__| || |  | || |____ ");
        Console.WriteLine(@"            \/    \/     |______||______| \_____| \____/ |_|  |_||______|");
        Console.WriteLine();
        Console.WriteLine(@"                    _______  ____    _______  _    _  ______ ");
        Console.WriteLine(@"                   |__   __|/ __ \  |__   __|| |  | ||  ____|");
        Console.WriteLine(@"                      | |  | |  | |    | |   | |__| || |__   ");
        Console.WriteLine(@"                      | |  | |  | |    | |   |  __  ||  __|  ");
        Console.WriteLine(@"                      | |  | |__| |    | |   | |  | || |____ ");
        Console.WriteLine(@"                      |_|   \____/     |_|   |_|  |_||______|");
        Console.WriteLine();
        Console.WriteLine(@"      _____   _    _  _____  _____  _       ______   _____          __  __  ______ ");
        Console.WriteLine(@"     |  __ \ | |  | ||__   ||__   || |     |  ____| / ____|   /\   |  \/  ||  ____|");
        Console.WriteLine(@"     | |__) || |  | |   / /    / / | |     | |__   | |  __   /  \  | \  / || |__   ");
        Console.WriteLine(@"     |  ___/ | |  | |  / /    / /  | |     |  __|  | | |_ | / /\ \ | |\/| ||  __|  ");
        Console.WriteLine(@"     | |     | |__| | / /__  / /__ | |____ | |____ | |__| |/ ____ \| |  | || |____ ");
        Console.WriteLine(@"     |_|      \____/ /_____|/_____||______||______| \_____/_/    \_\_|  |_||______|");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine();
    }

    public Board DifficultyChoice()
    {
        Console.Write("     1 = 3x3\n     2 = 4x4\n     3 = 5x5\n     4 = 6x6\n\n     Choose a difficulty:  ");

        string? playerInput = Console.ReadLine();
        return playerInput switch
        {
            //"0" => new(2, 2, _score), // this is only for testing
            "1" => new(3, 3, _score),
            "2" => new(4, 4, _score),
            "3" => new(5, 5, _score),
            "4" => new(6, 6, _score),
            _ => new(3, 3, _score) //if any other input is done  3x3 is the custom board
        };
    }
}
