
using PuzzleGame;

Console.Title = "Puzzle Game";

Score score = new Score();
StartMenu runGame = new StartMenu(score);
runGame.DisplayStartMenu();

Board board = runGame.DifficultyChoice();
Player player = new Player(board, score);
player.Move();

