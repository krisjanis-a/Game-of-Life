using System;

namespace GameOfLife
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            EntryPoint:

            Console.WriteLine("Game of Life");

            // PART 1 - Create board with random live cells

            int boardHeight = 10;
            int boardWidth = 30;
            //int deadCellPercentage = 10; // higher number = less alive cells

            // Random cell population
            Random population = new Random();
            int deadCellPercentage = population.Next(0, 100);
            Console.WriteLine("Dead cell percentage: " + deadCellPercentage);

            int[,] gameBoard = new int[boardHeight, boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    gameBoard[i, j] = 0;
                }
            }

            // Fill board with dead and alive cells at random

            Random random = new Random();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardWidth;)
                {
                    double randomNumber = random.Next(0,100);

                    if (deadCellPercentage < randomNumber)
                    {
                        gameBoard[i, j] = 1;
                    }

                    j++;

                }

                i++;
            }

            // Print board

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    if (gameBoard[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("#");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("+");
                        Console.ResetColor();
                    }
                }

                Console.WriteLine("");

            }

            Console.ResetColor();


            // Reload board

            Console.WriteLine("Would you like to reload the board?");

            Console.WriteLine("Yes - press [y]");
            Console.WriteLine("No - press [n]");

            var reloadBoard = false;

            while (true)
            {
                ConsoleKeyInfo result = Console.ReadKey();
                Console.Clear();

                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    reloadBoard = true;
                    break;
                }

                if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    reloadBoard = false;
                    break;
                }

                {
                    Console.Clear();
                    Console.WriteLine("Would you like to reload the board?");
                    Console.WriteLine("Yes - press [y]");
                    Console.WriteLine("No - press [n]");
                }
            }

            if (reloadBoard == true)
            {
                goto EntryPoint;
            }


        }
    }
}
