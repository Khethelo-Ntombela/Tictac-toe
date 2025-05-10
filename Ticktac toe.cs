using System;

class TicTacToe
{
    static char[,] board = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };
    static char currentPlayer = 'X';

    static void Main()
    {
        int turns = 0;
        bool gameRunning = true;

        while (gameRunning)
        {
            Console.Clear();
            PrintBoard();
            Console.WriteLine($"Player {currentPlayer}, enter a number (1-9) to place your move:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
            {
                if (MakeMove(position))
                {
                    turns++;
                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameRunning = false;
                    }
                    else if (turns == 9)
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine("It's a tie!");
                        gameRunning = false;
                    }
                    else
                    {
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
                Console.ReadLine();
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("\n {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} \n", board[2, 0], board[2, 1], board[2, 2]);
    }

    static bool MakeMove(int position)
    {
        int row = (position - 1) / 3;
        int col = (position - 1) % 3;
        if (board[row, col] != 'X' && board[row, col] != 'O')
        {
            board[row, col] = currentPlayer;
            return true;
        }
        return false;
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            // Check rows and columns
            if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) ||
                (board[0, i] == board[1, i] && board[1, i] == board[2, i]))
            {
                return true;
            }
        }
        // Check diagonals
        if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
            (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
        {
            return true;
        }
        return false;
    }
}
