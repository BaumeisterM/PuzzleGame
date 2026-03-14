using System.Text.Json;

namespace PuzzleGame;

public class Score
{
    public void DisplayScore(string name, int moves, string datetime, Board board)
    {
        SaveScore(name, moves, datetime, board);

        Console.CursorVisible = false;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"         _   _ ___ ____ _   _ ____   ____ ___  ____  _____ ");
        Console.WriteLine(@"        | | | |_ _/ ___| | | / ___| / ___/ _ \|  _ \| ____|");
        Console.WriteLine(@"        | |_| || | |  _| |_| \___ \| |  | | | | |_) |  _|  ");
        Console.WriteLine(@"        |  _  || | |_| |  _  |___) | |__| |_| |  _ <| |___ ");
        Console.WriteLine(@"        |_| |_|___\____|_| |_|____/ \____\___/|_| \_\_____|");
        Console.ResetColor();

        //Display highscorelist
        string filename = $"score_{board.Rows}x{board.Columns}.json";

        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            var scores = JsonSerializer.Deserialize<List<HighscoreEntry>>(json);

            Console.WriteLine($"\n              --- TOP SCORES {board.Rows}x{board.Columns} ---");
            Console.WriteLine("         Date        |   Name        |   Moves");
            Console.WriteLine("         -----------------------------------------");

            if (scores != null)
            {
                foreach (var s in scores)
                    Console.WriteLine($"        {s.Date}    |   {s.Name}    |   {s.Moves} Moves");
            }
        }
        else
            Console.WriteLine("         No Highscore available");

        BlinkPressAnyKey();
    }

    public void SaveScore(string name, int moves, string date, Board board)
    {
        string filename = $"score_{board.Rows}x{board.Columns}.json";

        // Load existing list or create new one
        List<HighscoreEntry> scores = new();
        if (File.Exists(filename))
        {
            try
            {
                string existingJson = File.ReadAllText(filename);
                scores = JsonSerializer.Deserialize<List<HighscoreEntry>>(existingJson) ?? new List<HighscoreEntry>();
            }
            catch { }
        }

        // Add new score
        scores.Add(new HighscoreEntry { Name = name, Moves = moves, Date = date });

        // sorted highscorelist
        var sortedScores = scores.OrderBy(s => s.Moves).Take(10).ToList(); // Top 10

        string jsonString = JsonSerializer.Serialize(sortedScores, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, jsonString);
    }

    private void BlinkPressAnyKey()
    {
        Console.WriteLine();
        bool showText = true;
        int blinkRow = Console.CursorTop;

        while (!Console.KeyAvailable)
        {
            Console.SetCursorPosition(0, blinkRow);
            if (showText)
                Console.WriteLine("         >> Press any key to end . . . << ");
            else
                Console.WriteLine("                                          ");

            showText = !showText;
            Thread.Sleep(500);
        }
        Console.ReadKey(true);
    }
}
