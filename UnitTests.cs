using System;
namespace GameOfLife
{
    public class UnitTests
    {
        public UnitTests()
        {
            // Empty board

            int[,] init_test0 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            int[,] expected_test0 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            // Single live cell in midle

            int[,] init_test1 = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };

            int[,] expected_test1 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            // Single live cell in midle

            int[,] init_test2 = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };

            int[,] expected_test2 = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }
    }
}
