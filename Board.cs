namespace PuzzleGame;

public class Board
{
    private readonly Random _rnd = new Random();
    private readonly int[,] _board;
    private int _gapRow;
    private int _gapCol;

    public int Rows { get; }
    public int Columns { get; }
    public bool IsSolved
    {
        get
        {
            if (_board[Rows - 1, Columns - 1] != 0) return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    // skip void last field
                    if (i == Rows - 1 && j == Columns - 1) continue;
                    int expectedValue = i * Columns + j + 1;
                    if (_board[i, j] != expectedValue) return false;
                }
            }
            return true;
        }
    }

    public Board(int rows, int columns, Score score)
    {
        Rows = rows;
        Columns = columns;
        _board = new int[rows, columns];

        // last field is void field (0)
        _board[rows - 1, columns - 1] = 0;
        _gapRow = rows - 1;
        _gapCol = columns - 1;

        // fill the board
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < columns; j++)
                _board[i, j] = i * columns + j + 1;

        _board[rows - 1, columns - 1] = 0;  // void field
        _gapRow = rows - 1;
        _gapCol = columns - 1;

        ShuffleBoard();
    }

    private void ShuffleBoard()
    {
        int lastRowChange = 0;
        int lastColChange = 0;

        //swaps empty field randomly
        for (int swaps = 0; swaps < 1000; swaps++)
        {
            int rnd = _rnd.Next(0, 4);

            (int rowChange, int colChange) = rnd switch
            {
                0 => (-1, 0),// Up
                1 => (1, 0), // Down
                2 => (0, -1),// Left
                3 => (0, 1), // Right
                _ => (0, 0)  // Fallback 
            };

            // backtracking -- prevent new move from undoing the previous one
            // example: if last move was Up (-1,0), the direct opposite would be Down (1,0)
            if (rowChange == -lastRowChange && colChange == -lastColChange)
            {
                swaps--;
                continue;
            }

            // Validate Move
            if (TryMove(rowChange, colChange))
            {
                // Remind last move
                lastRowChange = rowChange;
                lastColChange = colChange;
            }
            else
                // Invalid moves don't count;
                swaps--;
        }
    }

    public bool TryMove(int rowChange, int colChange)
    {
        int newRow = _gapRow + rowChange;
        int newCol = _gapCol + colChange;

        // Validate new position
        if (IsMoveValid(newRow, newCol))
        {
            SwapPosition(_gapRow, _gapCol, newRow, newCol);
            _gapRow = newRow;
            _gapCol = newCol;
            return true; // Valid move
        }
        return false; // Invalid move
    }

    private void SwapPosition(int r1, int c1, int r2, int c2)
    {
        int temp = _board[r1, c1];
        _board[r1, c1] = _board[r2, c2];
        _board[r2, c2] = temp;
    }

    public bool IsMoveValid(int r, int c)   //validate if is in range
    {
        return r >= 0 && r < Rows && c >= 0 && c < Columns;
    }

    public void DisplayBoard(int moves)
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        for (int i = 0; i < Rows; i++)
        {
            Console.Write("\t\t");
            // 1.top
            for (int j = 0; j < Columns; j++)
            {
                DrawSpritePart(i, j, " ┌───────┐ ");
            }
            Console.WriteLine();
            Console.Write("\t\t");
            // 2. mid
            for (int j = 0; j < Columns; j++)
            {
                int val = _board[i, j];
                string content = val == 0 ? " │       │ " : $" │   {val,2}  │ ";
                DrawSpritePart(i, j, content);
            }
            Console.WriteLine();
            Console.Write("\t\t");
            // 3. bottom
            for (int j = 0; j < Columns; j++)
            {
                DrawSpritePart(i, j, " └───────┘ ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\n\t\tMoves: {moves}");
    }

    // helper to color the fields
    private void DrawSpritePart(int row, int col, string part)
    {
        int val = _board[row, col];
        int target = row * Columns + col + 1;

        if (val != 0)
            Console.ForegroundColor = (val == target) ? ConsoleColor.Green : ConsoleColor.Gray;

        Console.Write(part);
        Console.ResetColor();
    }
}
