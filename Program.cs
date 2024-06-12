

class Program
{
    static char[,] board = new char[3, 3];
    static char currentPlayer = 'X';

    static void Main()
    {
        InitializeBoard();

        while (true)
        {
            PrintBoard();
            PlayerMove();
            if (CheckWin())
            {
                PrintBoard();
                Console.WriteLine($"Играч {currentPlayer} печели!");
                break;
            }
            if (CheckDraw())
            {
                PrintBoard();
                Console.WriteLine("Играта е равна!");
                break;
            }
            SwitchPlayer();
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    static void PlayerMove()
    {
        int row, col;
        while (true)
        {
            Console.WriteLine($"Играч {currentPlayer}, въведете ред и колона (0, 1 или 2): ");
            Console.Write("Ред: ");
            row = int.Parse(Console.ReadLine());
            Console.Write("Колона: ");
            col = int.Parse(Console.ReadLine());

            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
                break;
            }
            else
            {
                Console.WriteLine("Невалиден ход, опитайте отново.");
            }
        }
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool CheckWin()
    {
        // Проверка на редове, колони и диагонали
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer) ||
                (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer))
            {
                return true;
            }
        }

        if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
            (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
        {
            return true;
        }

        return false;
    }

    static bool CheckDraw()
    {
        foreach (char c in board)
        {
            if (c == ' ')
            {
                return false;
            }
        }
        return true;
    }
}
