using System;

namespace MagicSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int order = 3;
            int startValue;
            
            Console.Write("Enter the startValue: ");
            if (int.TryParse(Console.ReadLine(), out startValue))
            {
                Console.WriteLine();

                int[,] magicSquare = new int[order, order];

                int row = 0;
                int col = order / 2;

                for (int i = 0; i < order; i++)
                {
                    for (int j = 0; j < order; j++)
                    {
                        magicSquare[i, j] = -1;
                    }
                }

                magicSquare[row, col] = startValue;

                for (int num = startValue + 1; num <= startValue + (order * order) - 1; num++)
                {
                    int previousRow = row;
                    int previousCol = col;

                    row = row - 1;
                    col = col + 1;

                    if (row < 0)
                    {
                        row = order - 1;
                    }
                    if (col >= order)
                    {
                        col = 0;
                    }

                    if (magicSquare[row, col] != -1)
                    {
                        row = previousRow + 1;
                        col = previousCol;
                    }

                    magicSquare[row, col] = num;
                }

                string output = "";
                for (int i = 0; i < order; i++)
                {
                    for (int j = 0; j < order; j++)
                    {
                        output += magicSquare[i, j] + " ";
                    }
                    output += "\n";
                }

                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Invalid startValue input.");
            }
        }
    }
}
