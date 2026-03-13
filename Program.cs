// [x] The player needs to be able to manipulate the board to rearrange it.
// [x] The current state of the game needs to be displayed to the user.
// [x] The game needs to detect when it has been solved and tell the player they won.
// [x] The game needs to be able to generate random puzzles to solve.
// [x] The game needs to track and display how many moves the player has made.
// [] Save Moves and Input 3 letters (Highscore)

using PuzzleGame;

Console.Title = "Puzzle Game";

Score score = new Score();
StartMenu runGame = new StartMenu(score);
runGame.DisplayStartMenu();

Board board = runGame.DifficultyChoice();
Player player = new Player(board, score);
player.Move();

