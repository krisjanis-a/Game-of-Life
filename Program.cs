using System;

namespace GameOfLife
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            EntryPoint:

            // PART 1 - Create board with random live cells

            int boardHeight = 20;
            int boardWidth = 20;
            //int deadCellPercentage = 10; // higher number = less alive cells

            // Random cell population

            Random population = new Random();
            int deadCellPercentage = population.Next(0, 100);

            // Create empty board

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


            // Manually fill the board


            //gameBoard[2, 2] = 1;
            //gameBoard[2, 3] = 1;
            //gameBoard[2, 4] = 1;
            //gameBoard[3, 1] = 1;
            //gameBoard[3, 2] = 1;
            //gameBoard[3, 3] = 1;

            // Print board

            PrintCurrentBoard:

            Console.WriteLine("Game of Life");
            //Console.WriteLine("Dead cell percentage: " + deadCellPercentage);

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
                ConsoleKeyInfo result = Console.ReadKey(false);
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

                else
                {
                    goto PrintCurrentBoard;
                }
            }

            if (reloadBoard == true)
            {
                goto EntryPoint;
            }

            // PART 2 - Calculate next board state

            //Console.WriteLine("Press any key to print next board state");
            //Console.ReadKey(false);
            //Console.Clear();

            //int[,] nextBoardState = new int[boardHeight, boardWidth];
            //int[,] currentBoardState = new int[boardHeight,boardHeight];

            //currentBoardState = gameBoard;

            //nextBoardState = CalculateNextBoardState(currentBoardState);

            //Console.WriteLine("Next board state");

            //for (int i = 0; i < boardHeight; i++)
            //{
            //    for (int j = 0; j < boardWidth; j++)
            //    {
            //        if (nextBoardState[i, j] == 1)
            //        {
            //            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //            Console.Write("#");
            //            Console.ResetColor();
            //        }

            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.DarkRed;
            //            Console.Write("+");
            //            Console.ResetColor();
            //        }
            //    }

            //    Console.WriteLine("");

            //}

            //Console.ResetColor();



            // PART 3 - Make system alive: calculate and print next board state after specific time delay

            Console.WriteLine("Press any key to start Game of Life");
            Console.ReadKey(false);
            Console.Clear();

            int[,] nextBoardState = new int[boardHeight, boardWidth];
            int[,] currentBoardState = new int[boardHeight, boardHeight];

            currentBoardState = gameBoard;

            // Print initial board state

            Console.WriteLine("Current itteration: 0. To stop the game, press spacebar.");

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    if (currentBoardState[i, j] == 1)
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

            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            // Start calculating and printing further board states

            int currentItteration = 1;

            bool allBoardDead = false;

            while (allBoardDead == false)
            {
                nextBoardState = CalculateNextBoardState(currentBoardState);

                Console.WriteLine("Current itteration: {0}. To stop the game, press spacebar.", currentItteration);

                for (int i = 0; i < boardHeight; i++)
                {
                    for (int j = 0; j < boardWidth; j++)
                    {
                        if (nextBoardState[i, j] == 1)
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

                System.Threading.Thread.Sleep(1000);

                for (int i = 0; i < boardHeight; i++)
                {
                    for (int j = 0; j < boardWidth; j++)
                    {
                        if (nextBoardState[i, j] == 1)
                        {
                            Console.Clear();
                            goto EndCheck;
                        }

                        if ((i == boardHeight-1 & j == boardWidth-1) & nextBoardState[i,j] == 0)
                        {
                            allBoardDead = true;
                        }
                    }
                }

                EndCheck:

                currentBoardState = nextBoardState;
                currentItteration += 1;
            }

            Console.WriteLine("All board is dead.");

        }


        // Function to calculate next board state

        public static int[,] CalculateNextBoardState(int[,] currentBoardState)
        {

            int boardHeight = currentBoardState.GetLength(0);
            int boardWidth = currentBoardState.GetLength(1);

            int[,] NextBoardState = new int[boardHeight, boardHeight];

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardWidth;)
                {
                    int cellUp = 0;
                    int cellDown = 0;
                    int cellLeft = 0;
                    int cellRight = 0;

                    int cellUpLeft = 0;
                    int cellUpRight = 0;
                    int cellDownLeft = 0;
                    int cellDownRight = 0;

                    // Check every cell except the outer parts of board

                    if ((0 < i & i < boardHeight - 1) & (0 < j & j < boardWidth - 1))
                    {
                        cellUpLeft = currentBoardState[i - 1,j - 1];
                        cellUp = currentBoardState[i - 1, j];
                        cellUpRight = currentBoardState[i - 1, j + 1];
                        cellLeft = currentBoardState[i, j - 1];
                        cellRight = currentBoardState[i, j + 1];
                        cellDownLeft = currentBoardState[i + 1, j - 1];
                        cellDown = currentBoardState[i + 1, j];
                        cellDownRight = currentBoardState[i + 1, j + 1];

                        int aliveCellCount = 0;

                        aliveCellCount = cellUpLeft + cellUp + cellUpRight + cellLeft + cellRight + cellDownLeft + cellDown + cellDownRight;

                        if (currentBoardState[i,j] == 1)
                        {
                            if (aliveCellCount == 0 | aliveCellCount == 1)
                            {
                                NextBoardState[i, j] = 0;
                            }

                            if (aliveCellCount == 2 | aliveCellCount == 3)
                            {
                                NextBoardState[i, j] = 1;
                            }

                            if (3 < aliveCellCount)
                            {
                                NextBoardState[i, j] = 0;
                            }
                        }

                        if (currentBoardState[i, j] == 0)
                        {
                            if (aliveCellCount != 3)
                            {
                                NextBoardState[i, j] = 0;
                            }

                            if (aliveCellCount == 3)
                            {
                                NextBoardState[i, j] = 1;
                            }
                        }
                    }

                    // Check cells on first row

                    if (i == 0)
                    {
                        int aliveCellCount = 0;

                        // Check first cell
                        if (j == 0)
                        {
                            cellRight = currentBoardState[i, j + 1];
                            cellDown = currentBoardState[i + 1, j];
                            cellDownRight = currentBoardState[i + 1, j + 1];

                            aliveCellCount = cellRight + cellDown + cellDownRight;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                        // Check last cell
                        if (j == boardWidth - 1)
                        {
                            cellLeft = currentBoardState[i, j - 1];
                            cellDownLeft = currentBoardState[i + 1, j - 1];
                            cellDown = currentBoardState[i + 1, j];

                            aliveCellCount =  cellLeft + cellDownLeft + cellDown;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                        // Check rest of the row

                        if (j != 0 & j != boardWidth - 1)
                        {
                            cellLeft = currentBoardState[i, j - 1];
                            cellRight = currentBoardState[i, j + 1];
                            cellDownLeft = currentBoardState[i + 1, j - 1];
                            cellDown = currentBoardState[i + 1, j];
                            cellDownRight = currentBoardState[i + 1, j + 1];

                            aliveCellCount = cellLeft + cellRight + cellDownLeft + cellDown + cellDownRight;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                    }

                    // Check cells on last row

                    if (i == boardHeight - 1)
                    {
                        int aliveCellCount = 0;

                        // Check first cell
                        if (j == 0)
                        {
                            cellRight = currentBoardState[i, j + 1];
                            cellUp = currentBoardState[i - 1, j];
                            cellUpRight = currentBoardState[i - 1, j + 1];

                            aliveCellCount = cellRight + cellUp + cellUpRight;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                        // Check last cell
                        if (j == boardWidth - 1)
                        {
                            cellLeft = currentBoardState[i, j - 1];
                            cellUpLeft = currentBoardState[i - 1, j - 1];
                            cellUp = currentBoardState[i - 1, j];

                            aliveCellCount = cellLeft + cellUpLeft + cellUp;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                        // Check rest of the row

                        if (j != 0 & j != boardWidth - 1)
                        {
                            cellLeft = currentBoardState[i, j - 1];
                            cellRight = currentBoardState[i, j + 1];
                            cellUpLeft = currentBoardState[i - 1, j - 1];
                            cellUp = currentBoardState[i - 1, j];
                            cellUpRight = currentBoardState[i - 1, j + 1];

                            aliveCellCount = cellLeft + cellRight + cellUpLeft + cellUp + cellUpRight;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }
                    }

                    // Check cells on sides

                    if ( i != 0 & i != boardHeight - 1)
                    {
                        // Check left side
                        if(j == 0)
                        {
                            cellUp = currentBoardState[i - 1, j];
                            cellUpRight = currentBoardState[i - 1, j + 1];
                            cellRight = currentBoardState[i, j + 1];
                            cellDown = currentBoardState[i + 1, j];
                            cellDownRight = currentBoardState[i + 1, j + 1];

                            int aliveCellCount = 0;

                            aliveCellCount = cellUp + cellUpRight + cellRight + cellDown + cellDownRight;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                        // Check right side
                        if(j == boardWidth -1)
                        {
                            cellUpLeft = currentBoardState[i - 1, j - 1];
                            cellUp = currentBoardState[i - 1, j];
                            cellLeft = currentBoardState[i, j - 1];
                            cellDownLeft = currentBoardState[i + 1, j - 1];
                            cellDown = currentBoardState[i + 1, j];

                            int aliveCellCount = 0;

                            aliveCellCount = cellUpLeft + cellUp+ cellLeft+ cellDownLeft + cellDown;

                            if (currentBoardState[i, j] == 1)
                            {
                                if (aliveCellCount == 0 | aliveCellCount == 1)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 2 | aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }

                                if (3 < aliveCellCount)
                                {
                                    NextBoardState[i, j] = 0;
                                }
                            }

                            if (currentBoardState[i, j] == 0)
                            {
                                if (aliveCellCount != 3)
                                {
                                    NextBoardState[i, j] = 0;
                                }

                                if (aliveCellCount == 3)
                                {
                                    NextBoardState[i, j] = 1;
                                }
                            }
                        }

                    }

                    j++;
                }

                i++;
            }

            return NextBoardState;
        }
    }
}
